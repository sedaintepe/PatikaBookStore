using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PatikaBookStoreWebapi.DbOperations
{
 public class DataGenerator
 {
     public static void Initialize(IServiceProvider serviceProvider)
     {
         using (var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
         {
             if(context.Books.Any()) return;
             context.Books.AddRange(
                   new Book{
         // Id=1,
          Title="savaş",//romantik
          GenreId=1,
          PageCount=100,
          PublishDate=new DateTime(2000,1,03)
        },
         new Book{
        //  Id=2,
          Title="barış",//macera
          GenreId=2,
          PageCount=200,
          PublishDate=new DateTime(1999,2,03)

        },
         new Book{
         // Id=3,
          Title="ceza",
          GenreId=3,//suç
          PageCount=400,
          PublishDate=new DateTime(1999,2,21)

    }
             );
             context.SaveChanges();
         }
     }
 }




}