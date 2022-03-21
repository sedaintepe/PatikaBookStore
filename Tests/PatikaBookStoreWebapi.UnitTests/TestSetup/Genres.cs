using System;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace TestSetup
{
    public static class Genres
    {//nokta ile erişilebilsin
        public static void AddGenres(this BookStoreDbContext context) //static class altında statıc metodlar olmalı
        {
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
          


        } 

    }
}