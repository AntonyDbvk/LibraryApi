namespace Library.API.DTOs.BookInstanceDtos
{
    public class UserBookInstance
    {
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public DateTime BorrowedAt { get; set; } 
        public DateTime ReturnBy { get; set; }   
    }
}
