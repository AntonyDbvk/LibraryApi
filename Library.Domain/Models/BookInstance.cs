using System;

namespace Library.Domain.Models
{
    public class BookInstance
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime ReturnBy { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
