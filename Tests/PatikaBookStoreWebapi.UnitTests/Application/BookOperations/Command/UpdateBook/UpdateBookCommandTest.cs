using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.UpdateBook;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.BookOperations.Command.UpdateBook
{
    public class UpdateBookCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public UpdateBookCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
         //tetsler genelde bir şey donmez geriye

         [Fact]  //test old bellli etmek için
       public void WhenAlreadyUpdateBookTitleIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var book=new Book(){Title="Test_WhenAlreadyUpdateBookTitleIsGiven_InvalidOperationException_ShouldReturn",PageCount=100,PublishDate=new DateTime(1992,01,02),GenreId=1}; //test için ayrı bir tek bir seferlik veri olusturduk
           _context.Books.Update(book); 
           _context.SaveChanges();

           UpdateBookCommand command=new UpdateBookCommand(_context);
           command.Model=new UpdateViewModel(){Title=book.Title};
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kitap bulunamadı!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Book_ShouldBeUpdated()
       {
             UpdateBookCommand command=new UpdateBookCommand(_context);
            UpdateViewModel model=new UpdateViewModel()
            {Title="Hobbit",GenreId=1};
            command.BookId=2;
           command.Model=model;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var book=_context.Books.SingleOrDefault(book=>book.Title==model.Title);
            book.Should().NotBeNull();
            book.GenreId.Should().Be(model.GenreId);

       

       }
        
    }
}