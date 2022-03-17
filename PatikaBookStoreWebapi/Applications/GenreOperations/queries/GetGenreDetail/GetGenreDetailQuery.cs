
//Genre Listeleme
using PatikaBookStoreWebapi.DbOperations;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using System;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail{
    public class GetGenreDetailQuery{

        public int GenreId{get;set;}
        //dependicy
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  GenreDetailViewModel Handle(){
            var genre=_context.Genres.SingleOrDefault(x=>x.IsActive && x.Id==GenreId);//singleordefault bir tane veri almasınısağlar where daha cok
          if(genre is null) throw new InvalidOperationException("Kitap Türü Bulunamadı!");
          return _mapper.Map<GenreDetailViewModel>(genre);

        }
    }
    public class GenreDetailViewModel{
        public int Id { get; set; }
        public string GenreName { get; set; }
    }
}