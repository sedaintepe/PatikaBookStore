using System;
using System.Linq;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.commands.CreateGenre{
    public class CreateGenreCommands{
        public CreateGenreModel _model{get;set;}
        private readonly IBookStoreDbContext _context;

        public CreateGenreCommands(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var genre=_context.Genres.SingleOrDefault(x=>x.Name==_model.Name);
            if(genre is not null) throw new InvalidOperationException("Kitap Türü Zaten Mevcut!");

            genre=new Genre();//mapleme
            genre.Name=_model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();


        }
    }
    public class CreateGenreModel{
        public string Name { get; set; }
    }
}
