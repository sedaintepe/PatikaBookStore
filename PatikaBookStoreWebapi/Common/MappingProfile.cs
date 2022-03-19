using AutoMapper;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenres;
using PatikaBookStoreWebapi.Entities;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;
using static PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks.GetBooksQuery;

namespace PatikaBookStoreWebapi.Common{

    public class MappingProfile:Profile{
       public MappingProfile()
       {
           CreateMap<CreateBook,Book>(); //createBook u Booka dönüştür
           CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
           CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
           CreateMap<Genre,GetGenreViewModel>();//genre yi getgenreVM dönüştür.
            CreateMap<Genre,GenreDetailViewModel>();
           
       }
    }
}