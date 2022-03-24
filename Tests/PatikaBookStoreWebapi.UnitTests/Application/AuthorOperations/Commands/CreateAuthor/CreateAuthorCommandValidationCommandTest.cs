using System;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor;
using TestSetup;
using Xunit;

namespace Application.AuthorOperations.Command.AuthorCommand
{
    public class CreateAuthorCommandValidationCommandTest:IClassFixture<CommonTestFicture>{
        [Theory]
        [InlineData("Harry","Steve",0)]
         [InlineData("Harry","",1)]
          [InlineData("","Steve",0)]
           [InlineData("","Steve",1)]
             [InlineData("","",0)]                  //hepsinnin valiid olmaması! lazımv hepsi doldurulmamalı
             [InlineData("","",1)]
              [InlineData("Har","",0)]
               [InlineData("Har","",1)]
            

       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(string Name,string surname,int bookId){
           //arrange
           CreateAuthorCommand command=new CreateAuthorCommand(null,null);
           command.Model= new CreateAuthor(){
               Name=Name,
               Surname=surname,
               BirthDate=DateTime.Now.Date.AddYears(-30),
               BookId=bookId
           };
           //act
           CreateAuthorCommandValidation validations=new CreateAuthorCommandValidation();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
       [Fact]
       public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnErro()
       {
           CreateAuthorCommand command=new CreateAuthorCommand(null,null);
           command.Model= new CreateAuthor(){
               Name="Harry",
               Surname="Steve",
               BirthDate=DateTime.Now.Date,
               BookId=2
           };
           //act
             CreateAuthorCommandValidation validations=new CreateAuthorCommandValidation();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);
       }
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
          CreateAuthorCommand command=new CreateAuthorCommand(null,null);
            command.Model= new CreateAuthor(){
               Name="Harry",
               Surname="Steve",
               BirthDate=DateTime.Now.Date.AddYears(-30),
               BookId=2
           };
           //act
           CreateAuthorCommandValidation validations=new CreateAuthorCommandValidation();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}