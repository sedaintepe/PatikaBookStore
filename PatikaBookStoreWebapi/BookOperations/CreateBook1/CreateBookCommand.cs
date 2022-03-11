using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.BookOperations.GetBooks;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.BookOperations.CreateBook1{
 public class CreateBookCommand{
     public CreateBook Model{get;set;}
     private readonly BookStoreDbContext _dbcontext;
  public CreateBookCommand(BookStoreDbContext dbContext){
       _dbcontext=dbContext;
  }
  public void Handle(){
      var book=_dbcontext.Books.SingleOrDefault(x=>x.Title==Model.Title);
      if(book is not null) throw new InvalidOperationException("Kitap zaten mevcut!");

      book=new Book();
      book.Title=Model.Title;
      book.GenreId=Model.GenreId;
      book.PageCount=Model.PageCount;
      book.PublishDate=Model.PublishDate;
      _dbcontext.Books.Add(book);
      _dbcontext.SaveChanges();
  }
  public class CreateBook{
      public int PageCount { get; set; }
      public string Title{get;set;}
      public int GenreId { get; set; }
      public DateTime PublishDate { get; set; }
  }



 }






}