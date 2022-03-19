using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any()) return;
                context.Genres.AddRange(
                  new Genre
                  {
                      Name = "Personel Growth"
                  },
                   new Genre
                   {
                       Name = "Science Fiction"
                   },
                   new Genre
                   {
                       Name = "Romance"
                   }
                );


                context.Books.AddRange(
                new Book
                {
                          // Id=1,
                 Title = "savaş",//romantik
                 GenreId = 1,
                 PageCount = 100,
                PublishDate = new DateTime(2000, 1, 03)
                      },
            new Book
            {
                //  Id=2,
                Title = "barış",//macera
                GenreId = 2,
                PageCount = 200,
                PublishDate = new DateTime(1999, 2, 03)

            },
            new Book
            {
                // Id=3,
                Title = "ceza",
                GenreId = 3,
                PageCount = 400,
                PublishDate = new DateTime(1999, 2, 21)

            }
                );
                context.Authors.AddRange(
                    new Author
                    {
                        Name="Orhan",
                        Surname="Kedi",
                        BirthDate=new DateTime(1889,1,20),
                        BookId=1
                        
                    },
                      new Author
                    {
                        Name="Ali",
                        Surname="Kirami",
                        BirthDate=new DateTime(1789,1,10),
                        BookId=2
                    
                    },
                      new Author
                    {
                        Name="Selen",
                        Surname="Vedi",
                        BirthDate=new DateTime(1879,2,10),
                        BookId=2
                    }

                );
                context.SaveChanges();
            }
        }
    }




}