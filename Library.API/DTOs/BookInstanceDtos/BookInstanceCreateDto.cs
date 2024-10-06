namespace Library.API.DTOs.BookInstanceDtos
{
    public class BookInstanceCreateDto
    {
        public Guid BookId { get; set; }         
        public Guid UserId { get; set; }         
        public DateTime BorrowedAt { get; set; } 
        public DateTime ReturnBy { get; set; }   
    }

}
