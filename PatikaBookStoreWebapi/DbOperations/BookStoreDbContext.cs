using Microsoft.EntityFrameworkCore;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.DbOperations{
    public class BookStoreDbContext:DbContext,IBookStoreDbContext{
      public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options){

      }
      public DbSet<Book> Books{get;set;}
     public DbSet<Genre> Genres{get;set;}
      public DbSet<Author> Authors{get;set;}

        public override int SaveChanges() //dbcontexttede, Ibookstoreda da oldugu için overrirde ederiz,startup.cs de inject etmemeiz lazım
        {
            return base.SaveChanges();
        }
    }
}