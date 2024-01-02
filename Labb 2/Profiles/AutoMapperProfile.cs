using AutoMapper;
using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AuthorDTO, Author>().ReverseMap();
        CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
        CreateMap<BookBorrower, BookBorrowerDTO>().ReverseMap();
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<Borrower, BorrowerDTO>().ReverseMap();

    }
}
