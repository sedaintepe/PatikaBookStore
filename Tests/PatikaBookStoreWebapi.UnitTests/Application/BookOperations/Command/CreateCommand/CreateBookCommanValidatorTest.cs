using System;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;

namespace Application.BookOperations.Command.CreateCommand{
    public class CreateBookCommanValidatorTest:IClassFixture<CommonTestFicture>{
        [Theory]
        [InlineData("Lord Of Rings",0,0)]//dısardan veri data alıyoruz bu teory ile 9 Inline demek 9 test demek
         [InlineData("Lord Of Rings",0,1)]
          [InlineData("",100,0)]
           [InlineData("",100,1)]
            [InlineData("Lord Of Rings",100,0)]  //hepsinnin valiid olmaması! lazımv hepsi doldurulmamalı
             [InlineData("",0,1)]
              [InlineData("Lord",0,0)]
               [InlineData("Lord",0,1)]
                [InlineData("Lord",100,0)]
               

       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(string title,int PageCount,int genreId){
           //arrange
           CreateBookCommand command=new CreateBookCommand(null,null);
           command.Model= new CreateBook(){
               Title=title,
               PageCount=PageCount,
               PublishDate=DateTime.Now.Date.AddYears(-1),
               GenreId=genreId
           };
           //act
           CreateBookCommandValidator validations=new CreateBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
       [Fact]
       public void WhenDateTimeEqualNowIsGiven_VAlidator_ShouldBeReturnErro()
       {
             CreateBookCommand command=new CreateBookCommand(null,null);
           command.Model= new CreateBook(){
               Title="Lord Of The Rings",
               PageCount=100,
               PublishDate=DateTime.Now.Date,
               GenreId=1
           };
           //act
           CreateBookCommandValidator validations=new CreateBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);
       }
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_VAlidator_ShouldNotBeReturnError()
       {
             CreateBookCommand command=new CreateBookCommand(null,null);
           command.Model= new CreateBook(){
               Title="Lord Of The Ring",
               PageCount=100,
               PublishDate=DateTime.Now.Date.AddYears(-2),
               GenreId=1
           };
           //act
           CreateBookCommandValidator validations=new CreateBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}