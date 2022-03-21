using System;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace TestSetup
{
    public static class Books
    {//nokta ile erişilebilsin
        public static void AddBooks(this BookStoreDbContext context) //static class altında statıc metodlar olmalı
        {

            context.Books.AddRange(
                        new Book
                        {   Title = "savaş", GenreId = 1,
                            PageCount = 100,
                            PublishDate = new DateTime(2000, 1, 03)
                        },
                    new Book
                    {
               
                        Title = "barış",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(1999, 2, 03)

                    },
                    new Book
                    {
               
                        Title = "ceza",
                        GenreId = 3,
                        PageCount = 400,
                        PublishDate = new DateTime(1999, 2, 21)

                    }
                        );




        } 

    }
}