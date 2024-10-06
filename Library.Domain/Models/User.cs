using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models
{
    public class User : IdentityUser<Guid> 
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 

        public ICollection<BookInstance> BookInstances { get; set; } = new List<BookInstance>();
    }
}
