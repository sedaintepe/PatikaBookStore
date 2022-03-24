using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.GenreOperations.Queries.GetDetailGenre
{
    public class GetDetailQueryGenreTest:IClassFixture<CommonTestFicture>{
        private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public GetDetailQueryGenreTest(CommonTestFicture testFicture){
         _context=testFicture.Context;
         _mapper=testFicture.Mapper;
       }
       
         [Fact] 
       public void WhenAlreadyListGenreNameIsGiven_InvalidOperationException_ShouldReturn(){

           //arrange - hazırlık
           var genre=new Genre(){Name="Test_ShouldReturn",IsActive=true}; 
           _context.Genres.Add(genre);
         //  _context.Books.Include(x=>x.Genre).Where(x=>x.Id==1).ToList();
           _context.SaveChanges();

           GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
           query.GenreId=0;
           //act   - çalıştırma &&  //assort - doğrulama
           FluentActions
             .Invoking(()=>query.Handle())//calışması gereken komutu veriyoz invoke
             .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı!");
          
       }
         [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Author_ShouldBeGetted()
       {
            GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
           query.GenreId=1;
           //act
           FluentActions
           .Invoking(()=>query.Handle())
           .Invoke();//calıstır demek
            //assorts
            //veri databasede var mı bak
            var genre=_context.Genres.SingleOrDefault(genre=>genre.Id==1 && genre.IsActive==true);
            genre.Should().NotBeNull();
           

       }
        
    }
}