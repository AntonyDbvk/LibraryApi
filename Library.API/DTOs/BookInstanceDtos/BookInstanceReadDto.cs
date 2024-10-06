namespace Library.API.DTOs.BookInstanceDtos
{
    public class BookInstanceReadDto
    {
        public Guid Id { get; set; }            
        public Guid BookId { get; set; }        
        public Guid UserId { get; set; }        
        public DateTime BorrowedAt { get; set; }
        public DateTime ReturnBy { get; set; }  
        public string BookTitle { get; set; }   
        public string UserName { get; set; }    
    }

}
