using Library.API.DTOs.BookInstanceDtos;
using Library.Domain.Models;

namespace Library.API.DTOs.UserDtos
{
    public class UserRead
    {
        public Guid Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }  
        public string Email { get; set; }      
        public List<UserBookInstance> BookInstances { get; set; } = new List<UserBookInstance>();
    }

}
