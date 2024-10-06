namespace Library.API.DTOs.BookDtos
{
    public class BookCreateDto
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int AvailableCopies { get; set; }
        public Guid AuthorId { get; set; }
    }

}
