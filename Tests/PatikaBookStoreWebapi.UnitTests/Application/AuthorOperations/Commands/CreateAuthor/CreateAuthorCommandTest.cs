using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public CreateAuthorCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
         //tetsler genelde bir şey donmez geriye

         [Fact]  //test old bellli etmek için
       public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var author=new Author(){Name="Test_ShouldReturn",Surname="Test_Surname",BirthDate=new DateTime(1992,01,02),BookId=1}; 
           _context.Authors.Add(author); 
           _context.SaveChanges();

           CreateAuthorCommand command=new CreateAuthorCommand(_context,_mapper);
           command.Model=new PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor.CreateAuthor(){Name=author.Name};
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("İsimli yazar zaten var!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
       {
             CreateAuthorCommand command=new CreateAuthorCommand(_context,_mapper);
            PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor.CreateAuthor model=new PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor.CreateAuthor()
            {Name="Hayat",Surname="Akan", BirthDate=DateTime.Now.Date.AddYears(-20),BookId=1};
           command.Model=model;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var author=_context.Authors.SingleOrDefault(author=>author.Name==model.Name);
            author.Should().NotBeNull();
            author.Surname.Should().Be(model.Surname);
            author.BirthDate.Should().Be(model.BirthDate);
            author.BookId.Should().Be(model.BookId);

       }
        
    }
}