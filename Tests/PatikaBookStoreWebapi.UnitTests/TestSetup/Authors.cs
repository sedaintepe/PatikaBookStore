using System;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace TestSetup
{
    public static class Authors
    {//nokta ile erişilebilsin
        public static void AddAuthors(this BookStoreDbContext context) //static class altında statıc metodlar olmalı
        {
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
          


        } 

    }
}