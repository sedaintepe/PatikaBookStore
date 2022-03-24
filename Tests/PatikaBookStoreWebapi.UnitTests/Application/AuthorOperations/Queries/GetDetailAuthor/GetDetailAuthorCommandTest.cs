using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthorDetail;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.AuthorOperations.Queries.GetDetailAuthor
{
    public class GetDetailAuthorCommandTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetDetailAuthorCommandTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
       
         [Fact] 
       public void WhenAlreadyListAuthorNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var author=new Author(){Name="Test_ShouldReturn",Surname="Test_Surname",BirthDate=new DateTime(1992,01,02),BookId=1}; 
           _context.Authors.Add(author);
         //  _context.Books.Include(x=>x.Genre).Where(x=>x.Id==1).ToList();
           _context.SaveChanges();

           GetAuthorDetailQuery query=new GetAuthorDetailQuery(_context,_mapper);
           query.AuthorId=0;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>query.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Author_ShouldBeGetted()
       {
            GetAuthorDetailQuery query=new GetAuthorDetailQuery(_context,_mapper);
           query.AuthorId=1;
           //act
           FluentActions
           .Invoking(()=>query.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var author=_context.Authors.SingleOrDefault(author=>author.Id==1);
            author.Should().NotBeNull();
           

       }
        
    }
}