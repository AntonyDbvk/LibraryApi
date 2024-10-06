using Library.Application.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Library.API.DTOs;
using AutoMapper;
using Library.API.DTOs.UserDtos;
using Library.API.DTOs.BookInstanceDtos;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Guid>> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid registration request." });
            }

            try
            {
                var userId = await _userService.RegisterUserAsync(request.Username, request.Password, request.FirstName, request.LastName, request.Email);
                return CreatedAtAction(nameof(GetUserById), new { id = userId }, new { id = userId });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid authentication request.");
            }

            try
            {
                var (token, userId) = await _userService.GenerateJwtTokenAsync(request.Username, request.Password);
                return Ok(new { token, userId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Unauthorized(new { message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            var users = await _userService.GetAllUsersAsync();
            if (users == null ) return NotFound();

            var result = _mapper.Map<List<UserRead>>(users);

            return Ok(result);   
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(); 
            }
            return Ok(user);
        }

        [HttpGet("bookinstance/{id}")]
        public async Task<ActionResult<List<UserBookInstance>>> GetUserBookInstanceById(Guid id)
        {
            var bookInstances = await _userService.GetBookInstancesByUserIdAsync(id);
            if (bookInstances == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<List<UserBookInstance>>(bookInstances);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("ID mismatch."); // 400 
            }

            var result = await _userService.UpdateUserAsync(user);
            if (result)
            {
                return NoContent(); // 204
            }
            else
            {
                return NotFound(); // 404
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return NoContent(); // 204
            }
            else
            {
                return NotFound(); 
            }
        }
    }

}
