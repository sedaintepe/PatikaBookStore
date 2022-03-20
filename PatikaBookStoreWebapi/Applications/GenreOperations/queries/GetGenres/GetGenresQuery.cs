
//Genre Listeleme
using PatikaBookStoreWebapi.DbOperations;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenres{
    public class GetGenresQuery{
        //dependicy
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<GetGenreViewModel> Handle(){
            var genres=_context.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id);
            List<GetGenreViewModel> returnObj=_mapper.Map<List<GetGenreViewModel>>(genres);
            return returnObj;

        }
    }
    public class GetGenreViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}