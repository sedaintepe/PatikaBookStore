using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook{
 public class DeleteBookCommand{
     public int BookId{get;set;}
     private readonly BookStoreDbContext _dbcontext;
     public DeleteBookCommand(BookStoreDbContext dbContext){
         _dbcontext=dbContext;
     }
     public void Handle(){
       var book=_dbcontext.Books.SingleOrDefault(x=>x.Id==BookId);
        if(book is null) throw new InvalidOperationException("Silinecek kitap bulunamadı!");
        _dbcontext.Books.Remove(book);
        _dbcontext.SaveChanges();
   
     }

 }
}