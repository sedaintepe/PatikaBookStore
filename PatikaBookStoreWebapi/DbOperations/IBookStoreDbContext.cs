using Microsoft.EntityFrameworkCore;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.DbOperations{
    public interface IBookStoreDbContext{
        DbSet<Book> Books{get;set;}
        DbSet<Genre> Genres {get;set;}
        DbSet<Author> Authors {get;set;}
        int SaveChanges();
        
    }
}