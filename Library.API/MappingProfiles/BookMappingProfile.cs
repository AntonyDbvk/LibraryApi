using AutoMapper;
using Library.API.DTOs.AuthorDtos;
using Library.API.DTOs.BookDtos;
using Library.API.DTOs.BookInstanceDtos;
using Library.API.DTOs.UserDtos;
using Library.Domain.Models;

namespace Library.API.MappingProfiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookReadDto>()
                .ForMember(dest => dest.Author,
                           opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}")).ReverseMap();

            CreateMap<BookCreateDto, Book>()
                          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())) // Устанавливаем новый Guid для Id
                          .ForMember(dest => dest.Author, opt => opt.Ignore()); // Игнорируем Author, так как он не должен быть установлен через DTO

            CreateMap<Author, AuthorReadDto>()
                          .ForMember(dest => dest.Books,
                           opt => opt.MapFrom(src => src.Books.Select(b => b.Title).ToList())).ReverseMap();

            CreateMap<AuthorCreateDto, Author>()
                           .AfterMap((src, dest) => dest.Id = Guid.NewGuid()) // Устанавливаем новый ID
                           .ForMember(dest => dest.Books, opt => opt.MapFrom(src => new List<Book>())); // Инициализируем пустой список книг

            CreateMap<BookInstance, BookInstanceReadDto>()
         .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
         .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

            // Преобразование из BookInstanceCreateDto в BookInstance
            CreateMap<BookInstanceCreateDto, BookInstance>();

            CreateMap<User, UserRead>()
          .ForMember(dest => dest.BookInstances, opt => opt.MapFrom(src => src.BookInstances));

            // Маппинг для BookInstance -> UserBookInstance
            CreateMap<BookInstance, UserBookInstance>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.Book.Author.FirstName} {src.Book.Author.LastName}"));


        }
    }
}
