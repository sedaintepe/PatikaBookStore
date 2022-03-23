using System;
using System.Linq;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.BookOperations.Command.DeleteBook{
    public class DeleteBookCommandTest:IClassFixture<CommonTestFicture>{
           
           public int BookId{get;set;}
           private readonly BookStoreDbContext _context;
        public DeleteBookCommandTest(CommonTestFicture testFicture)
        {
            _context = testFicture.Context;
        }
        
         [Fact]  //test old bellli etmek için
       public void WhenAlreadyDeletedBookTitleIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
                 var book=_context.Books.SingleOrDefault(book=>book.Id==2);
               _context.Books.Remove(book); 
           _context.SaveChanges();

          DeleteBookCommand command=new DeleteBookCommand(_context);
          command.BookId=BookId;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı!");
          
       }
          [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Book_ShouldBeDeleted()
       {
             DeleteBookCommand command=new DeleteBookCommand(_context);
            int Id=1;
           command.BookId=Id;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var book=_context.Books.SingleOrDefault(book=>book.Id==Id);
            book.Should().BeNull();
            



       }
        


    }
}