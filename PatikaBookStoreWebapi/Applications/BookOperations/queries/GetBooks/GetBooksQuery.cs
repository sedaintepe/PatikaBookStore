using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaBookStoreWebapi.Common;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks{
 public class GetBooksQuery{
     private readonly IBookStoreDbContext _dbcontext;
     private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle(){
         var bookList=_dbcontext.Books.Include(x=>x.Genre).OrderBy(x=>x.Id).ToList<Book>();
         List<BooksViewModel> vm= _mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
        //  foreach(var book in bookList){
        //      vm.Add(new BooksViewModel(){
        //          Title=book.Title,
        //          Genre=((GenreEnum)book.GenreId).ToString(),
        //          PageCount=book.PageCount,
        //          PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy")

        //      });
         //}
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