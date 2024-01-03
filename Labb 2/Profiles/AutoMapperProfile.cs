using AutoMapper;
using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddAuthorDTO, Author>().ReverseMap();
        CreateMap<AddBookDTO, Book>().ReverseMap();
        CreateMap<Borrower, AddBorrowerDTO>().ReverseMap();
        CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
        CreateMap<BookBorrower, BookBorrowerDTO>().ReverseMap();
    }
}
