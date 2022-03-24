using System;
using System.Linq;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.DeleteAuthor;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook;
using PatikaBookStoreWebapi.DbOperations;
using TestSetup;
using Xunit;


namespace Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommandTest:IClassFixture<CommonTestFicture>{
           
           public int AuthorId{get;set;}
           private readonly BookStoreDbContext _context;
         public DeleteAuthorCommandTest(CommonTestFicture testFicture)
        {
            _context = testFicture.Context;
        }
        
         [Fact]  //test old bellli etmek için
       public void WhenAlreadyDeletedAuthorNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
                 var author=_context.Authors.SingleOrDefault(author=>author.Id==2);
               _context.Authors.Remove(author); 
           _context.SaveChanges();

          DeleteAuthorCommand command=new DeleteAuthorCommand(_context);
          command.AuthorId=AuthorId;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yazar bulunamadı!");
          
       }
          [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Book_ShouldBeDeleted()
       {
            DeleteAuthorCommand command=new DeleteAuthorCommand(_context);
            int Id=1;
            command.AuthorId=Id;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var author=_context.Authors.SingleOrDefault(author=>author.Id==Id);
            author.Should().BeNull();
            



       }
        


    }
}