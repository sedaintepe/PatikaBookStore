using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Common;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.Applications.BookOperations.commands.UpdateBook{
 public class UpdateBookCommand{
     public int BookId{get;set;}
     public UpdateViewModel Model{get;set;}
     private readonly BookStoreDbContext _dbcontext;
   public UpdateBookCommand(BookStoreDbContext dbContext){
           _dbcontext=dbContext;
   }
   public void Handle(){
        var book=_dbcontext.Books.SingleOrDefault(x=>x.Id==BookId);
        if(book is null) throw new InvalidOperationException("Güncellenecek kitap bulunamadı!");

        book.GenreId=Model.GenreId!=default?Model.GenreId:book.GenreId;
        book.Title=Model.Title!=default?Model.Title:book.Title;
        _dbcontext.SaveChanges();
      
   }

 }
 public class UpdateViewModel{
     public string Title { get; set; }
     public int GenreId { get; set; }
 }
}