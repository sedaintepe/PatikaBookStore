using System;
using System.Linq;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.CreateGenre;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
            public CreateGenreCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
       
       }
         //tetsler genelde bir şey donmez geriye

         [Fact]  //test old bellli etmek için
       public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var genre=new Genre(){Name="Test_ShouldReturn",IsActive=true}; 
           _context.Genres.Add(genre); 
           _context.SaveChanges();

           CreateGenreCommands command=new CreateGenreCommands(_context);
           command._model=new CreateGenreModel(){Name=genre.Name};
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Zaten Mevcut!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
       {
             CreateGenreCommands command=new CreateGenreCommands(_context);
            CreateGenreModel model=new CreateGenreModel()
            {Name="Hayat"};
           command._model=model;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var genre=_context.Genres.SingleOrDefault(genre=>genre.Name==model.Name);
            genre.Should().NotBeNull();
           
       }
        
    }
}