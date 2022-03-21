using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;

namespace Application.BookOperations.Command.CreateCommand{
    public class CreateBookCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public CreateBookCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
         //tetsler genelde bir şey donmez geriye

         [Fact]  //test old bellli etmek için
       public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var book=new Book(){Title="Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn",PageCount=100,PublishDate=new DateTime(1992,01,02),GenreId=1}; //test için ayrı bir tek bir seferlik veri olusturduk
           _context.Books.Add(book); 
           _context.SaveChanges();

           CreateBookCommand command=new CreateBookCommand(_context,_mapper);
           command.Model=new CreateBook(){Title=book.Title};
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Book_ShouldBeCreated()
       {
             CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            CreateBook model=new CreateBook()
            {Title="Hobbit",PageCount=1000, PublishDate=DateTime.Now.Date.AddYears(-10),GenreId=1};
           command.Model=model;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var book=_context.Books.SingleOrDefault(book=>book.Title==model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);



       }
        
    }
}