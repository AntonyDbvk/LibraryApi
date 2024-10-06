using Library.Domain.Models;

namespace Library.API.DTOs.BookDtos
{
    public class BookReadDto
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int AvailableCopies { get; set; }
        public Guid AuthorId { get; set; }
        public string Author { get; set; }
        public bool IsOutOfStock => AvailableCopies <= 0;
    }
}
