using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;

namespace Assignment2API.Configurations
{
    public class MapperConfig : Profile
    {        
        public MapperConfig()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookAuthor, BookAuthorDTO>();
            CreateMap<BookAuthor, BookAuthorDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
