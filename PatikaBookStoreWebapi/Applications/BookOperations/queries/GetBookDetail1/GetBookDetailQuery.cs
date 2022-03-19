using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Common;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1{
 public class GetBookDetailQuery{
     private readonly BookStoreDbContext _dbcontext;
      private readonly IMapper _mapper;
     public int BookId{get;set;}
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle(){
         var book=_dbcontext.Books.Where(book=>book.Id==BookId).SingleOrDefault();
         if(book is null) throw new InvalidOperationException("Kitap Bulunamadı!");
         BookDetailViewModel vm= _mapper.Map<BookDetailViewModel>(book);//new BookDetailViewModel();
        //  vm.Title=book.Title;
        //  vm.PageCount=book.PageCount;
        //  vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
        //  vm.Genre=((GenreEnum)book.GenreId).ToString();
         return vm;
     }
 
 }
 public class BookDetailViewModel{
     public int PageCount { get; set; }
     public string Title { get; set; }
     public string Genre { get; set; }
     public string PublishDate{get;set;}
 }
}