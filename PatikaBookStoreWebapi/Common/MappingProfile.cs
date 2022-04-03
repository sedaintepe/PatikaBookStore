using AutoMapper;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthorDetail;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthors;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenres;
using PatikaBookStoreWebapi.Applications.UserOperations.Commands;
using PatikaBookStoreWebapi.Applications.UserOperations.Commands.CreateUser;
using PatikaBookStoreWebapi.Entities;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;
using static PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks.GetBooksQuery;


namespace PatikaBookStoreWebapi.Common
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBook, Book>(); //createBook u Booka dönüştür
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GetGenreViewModel>();//genre yi getgenreVM dönüştür.
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthor, Author>();
            CreateMap<Author, AuthorViewModel>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));
            CreateMap<Author,AuthorDetailViewModel>().ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));
             CreateMap<CreateUserModel , User>();


        }
    }
}