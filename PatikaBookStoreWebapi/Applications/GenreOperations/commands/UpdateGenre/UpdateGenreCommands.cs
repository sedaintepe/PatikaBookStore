using System;
using System.Linq;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.commands.UpdateGenre{
  
  public class UpdateGenreCommands{
      public int GenreId { get; set; }
      public UpdateGenreModel Model { get; set; }
      private readonly IBookStoreDbContext _context;
        public UpdateGenreCommands(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre=_context.Genres.SingleOrDefault(x=>x.Id==GenreId);
            if(genre is null) throw new InvalidOperationException("Kitap Bulunamadı");
            if(_context.Genres.Any(x=>x.Name.ToLower()==Model.Name.ToLower()&& x.Id!=GenreId))
            throw new InvalidOperationException("Aynı isimli kitap türü zaten var!");

            genre.Name=string.IsNullOrEmpty(Model.Name.Trim())? genre.Name:Model.Name; //update olarak girilmemişse bir isim zaten var olan ismi donsun
            genre.IsActive=Model.IsActive;
            _context.SaveChanges();
        }
    }
  public class UpdateGenreModel{
      public string Name { get; set; }
      public bool IsActive { get; set; }=true;
  }

}