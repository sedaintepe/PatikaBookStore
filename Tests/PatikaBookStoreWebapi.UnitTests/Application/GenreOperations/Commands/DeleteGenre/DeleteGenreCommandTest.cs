using System;
using System.Linq;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.DeleteGenre;
using PatikaBookStoreWebapi.DbOperations;
using TestSetup;
using Xunit;


namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTest:IClassFixture<CommonTestFicture>{
           
           public int GenreId{get;set;}
           private readonly BookStoreDbContext _context;
         public DeleteGenreCommandTest(CommonTestFicture testFicture)
        {
            _context = testFicture.Context;
        }
        
         [Fact]  //test old bellli etmek için
       public void WhenAlreadyDeletedAGenreNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
                 var genre=_context.Genres.SingleOrDefault(genre=>genre.Id==2);
               _context.Genres.Remove(genre); 
           _context.SaveChanges();

          DeleteGenreCommand command=new DeleteGenreCommand(_context);
          command.GenreId=GenreId;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı!!");
          
       }
          [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Genre_ShouldBeDeleted()
       {
            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            int Id=1;
            command.GenreId=Id;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var genre=_context.Genres.SingleOrDefault(genre=>genre.Id==Id);
            genre.Should().BeNull();
            



       }
        


    }
}