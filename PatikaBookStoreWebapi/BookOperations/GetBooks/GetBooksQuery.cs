using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Common;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.BookOperations.GetBooks{
 public class GetBooksQuery{
     private readonly BookStoreDbContext _dbcontext;
     public GetBooksQuery(BookStoreDbContext dbContext){
         _dbcontext=dbContext;
     }
     public List<BooksViewModel> Handle(){
         var bookList=_dbcontext.Books.OrderBy(x=>x.Id).ToList<Book>();
         List<BooksViewModel> vm=new List<BooksViewModel>();
         foreach(var book in bookList){
             vm.Add(new BooksViewModel(){
                 Title=book.Title,
                 Genre=((GenreEnum)book.GenreId).ToString(),
                 PageCount=book.PageCount,
                 PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy")

             });
         }
         return vm;
     }

     public class BooksViewModel
     {
          
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
     }
 }




}