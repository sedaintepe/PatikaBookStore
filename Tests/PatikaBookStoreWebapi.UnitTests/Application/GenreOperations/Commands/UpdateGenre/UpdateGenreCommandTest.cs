using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.UpdateAuthor;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.UpdateGenre;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
     
       public UpdateGenreCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
      
       }
         //tetsler genelde bir şey donmez geriye

         [Fact] 
       public void WhenAlreadyUpdateGenreNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
            var genre=new Genre(){Name="Test_ShouldReturn",IsActive=true}; 
            _context.Genres.Update(genre); 
           _context.SaveChanges();

           UpdateGenreCommands command=new UpdateGenreCommands(_context);
           command.Model=new UpdateGenreModel(){Name=genre.Name};
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı");
          
       }
          [Fact] 
       public void WhenSameGenreNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
         var genre=new Genre(){Name="Test_ShouldReturn",IsActive=true};           
           _context.Genres.Update(genre); 
           _context.SaveChanges();

           UpdateGenreCommands command=new UpdateGenreCommands(_context);
           command.Model=new UpdateGenreModel(){Name=genre.Name};
          command.GenreId=2;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimli kitap türü zaten var!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Genre_ShouldBeUpdated()
       {
             UpdateGenreCommands command=new UpdateGenreCommands(_context);
             UpdateGenreModel model=new UpdateGenreModel()
            {Name="Dram"};
            command.Model=model;
            command.GenreId=2;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var genre=_context.Genres.SingleOrDefault(genre=>genre.Name==model.Name);
            genre.Should().NotBeNull();
            genre.IsActive.Should().Be(model.IsActive);

       

       }
        
    }
}