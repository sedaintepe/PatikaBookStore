using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1{
 public class CreateBookCommand{
     public CreateBook Model{get;set;}
     private readonly BookStoreDbContext _dbcontext;
     private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public void Handle(){
      var book=_dbcontext.Books.SingleOrDefault(x=>x.Title==Model.Title);
      if(book is not null) throw new InvalidOperationException("Kitap zaten mevcut!");

      book=_mapper.Map<Book>(Model);
     // book=new Book();
      //Mapleme ile alttaki fazla kod ortadan kalktı.(AutoMapper)
    //   book.Title=Model.Title;
    //   book.GenreId=Model.GenreId;
    //   book.PageCount=Model.PageCount;
    //   book.PublishDate=Model.PublishDate;
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