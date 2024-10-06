using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.API.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService authorService,IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        //api/authors
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAuthors();
            var result = _mapper.Map<List<AuthorReadDto>>(authors);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(Guid id)
        {
            var author = await _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound(); 
            }
            var result = _mapper.Map<AuthorReadDto>(author);
            return Ok(result);
        }

        
        [HttpPost]
        public async Task<ActionResult<Guid>> AddAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            if (authorCreateDto == null)
            {
                return BadRequest("Author cannot be null."); 
            }

            var author = _mapper.Map<Author>(authorCreateDto); 
            Console.WriteLine($"Контроллер {author.Id} {author.FirstName}");
         
            var id = await _authorService.AddAuthor(author);

            return CreatedAtAction(nameof(GetAuthorById), new { id = id }, id);
        }


       
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(Guid id, [FromBody] AuthorCreateDto authorCreateDto)
        {

            var existingAuthor = await _authorService.GetAuthor(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            var author = _mapper.Map<Author>(authorCreateDto);
            author.Id = existingAuthor.Id;
            await _authorService.UpdateAuthor(author);
            return NoContent();
        }

 
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(Guid id)
        {
            var existingAuthor = await _authorService.GetAuthor(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            await _authorService.DeleteAuthor(id);
            return NoContent(); 
        }
    }
}
