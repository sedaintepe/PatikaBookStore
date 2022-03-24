using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.UpdateAuthor;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public UpdateAuthorCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
         //tetsler genelde bir şey donmez geriye

         [Fact] 
       public void WhenAlreadyUpdateAuthorNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var author=new Author(){Name="Test_ShouldReturn",Surname="Test_Surname",BirthDate=new DateTime(1992,01,02),BookId=1}; 
           _context.Authors.Update(author); 
           _context.SaveChanges();

           UpdateAuthorCommand command=new UpdateAuthorCommand(_context);
           command.Model=new AuthorUpdateViewModel(){Name=author.Name};
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenicek yazar bulunamadı!");
          
       }
          [Fact] 
       public void WhenSameAuthorNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var author=new Author(){Name="Test_ShouldReturn",Surname="Test_Surname",BirthDate=new DateTime(1992,01,02),BookId=1}; 
           _context.Authors.Update(author); 
           _context.SaveChanges();

           UpdateAuthorCommand command=new UpdateAuthorCommand(_context);
           command.Model=new AuthorUpdateViewModel(){Name=author.Name};
           command.AuthorId=2;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>command.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimli yazar zaten var!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInOutsAreGiven_Author_ShouldBeUpdated()
       {
             UpdateAuthorCommand command=new UpdateAuthorCommand(_context);
             AuthorUpdateViewModel model=new AuthorUpdateViewModel()
            {Name="Steve", BookId=2};
            command.Model=model;
            command.AuthorId=2;
           //act
           FluentActions
           .Invoking(()=>command.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var author=_context.Authors.SingleOrDefault(author=>author.Name==model.Name);
            author.Should().NotBeNull();
            author.BookId.Should().Be(model.BookId);

       

       }
        
    }
}