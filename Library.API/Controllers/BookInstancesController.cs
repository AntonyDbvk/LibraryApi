using AutoMapper;
using Library.API.DTOs.BookInstanceDtos;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookInstancesController : ControllerBase
    {
        private readonly IBookInstanceService _bookInstanceService;
        private readonly IMapper _mapper;

        public BookInstancesController(IBookInstanceService bookInstanceService, IMapper mapper)
        {
            _bookInstanceService = bookInstanceService;
            _mapper = mapper;
        }

  
        [HttpGet]
        public async Task<ActionResult<List<BookInstanceReadDto>>> GetAllBookInstances()
        {
            var bookInstances = await _bookInstanceService.GetAllBookInstances();
            var result = _mapper.Map<List<BookInstanceReadDto>>(bookInstances);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookInstanceReadDto>> GetBookInstance(Guid id)
        {
            var bookInstance = await _bookInstanceService.GetBookInstanceById(id);
            if (bookInstance == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<BookInstanceReadDto>(bookInstance);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddBookInstance([FromBody] BookInstanceCreateDto bookInstanceCreateDto)
        {
            if (bookInstanceCreateDto == null)
            {
                return BadRequest("Book instance cannot be null.");
            }

            var bookInstance = _mapper.Map<BookInstance>(bookInstanceCreateDto);
            var id = await _bookInstanceService.AddBookInstance(bookInstance);
            return CreatedAtAction(nameof(GetBookInstance), new { id = id }, id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookInstance(Guid id, [FromBody] BookInstanceCreateDto bookInstanceCreateDto)
        {
            var existingBookInstance = await _bookInstanceService.GetBookInstanceById(id);
            if (existingBookInstance == null)
            {
                return NotFound();
            }

            var bookInstance = _mapper.Map<BookInstance>(bookInstanceCreateDto);
            bookInstance.Id = existingBookInstance.Id;
            await _bookInstanceService.UpdateBookInstance(bookInstance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookInstance(Guid id)
        {
            var existingBookInstance = await _bookInstanceService.GetBookInstanceById(id);
            if (existingBookInstance == null)
            {
                return NotFound();
            }

            await _bookInstanceService.DeleteBookInstance(id);
            return NoContent();
        }
    }
}
