using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.BookOperations.Queries.GetDetailBooks{
    public class GetBooksDetailQueryTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetBooksDetailQueryTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
       
         [Fact] 
       public void WhenAlreadyListBookGenreIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var book=new Book(){Title="Test_WhenAlreadyListBookGeneIsGiven_InvalidOperationException_ShouldReturn",PageCount=100,PublishDate=new DateTime(1992,01,02),GenreId=1}; //test için ayrı bir tek bir seferlik veri olusturduk
           _context.Books.Add(book);
         //  _context.Books.Include(x=>x.Genre).Where(x=>x.Id==1).ToList();
           _context.SaveChanges();

           GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
           query.BookId=0;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>query.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Book_ShouldBeGetted()
       {
             GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
           query.BookId=1;
           //act
           FluentActions
           .Invoking(()=>query.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var book=_context.Books.SingleOrDefault(book=>book.Id==1);
            book.Should().NotBeNull();
           

       }
        
    }
}