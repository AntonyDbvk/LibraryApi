using Library.Domain.Models;

namespace Library.API.DTOs.AuthorDtos
{
    public class AuthorReadDto  
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Country { get; set; }
        public List<string> Books { get; set; }
    }

}
