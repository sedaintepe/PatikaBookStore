using System;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;


namespace Application.BookOperations.Queries.GetDetailBooks{
    public class GetBooksDetailQueryValidationTest:IClassFixture<CommonTestFicture>{
        [Theory]
        [InlineData(0)]
               

       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(int Id){
           //arrange
           GetBookDetailQuery query=new GetBookDetailQuery(null,null);
           query.BookId=Id;
           GetBookDetailQueryValidator validations=new GetBookDetailQueryValidator();
           var result=validations.Validate(query);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
      
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
              GetBookDetailQuery query=new GetBookDetailQuery(null,null);
               query.BookId=1;
           //act
         GetBookDetailQueryValidator validations=new GetBookDetailQueryValidator();
           var result=validations.Validate(query);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}