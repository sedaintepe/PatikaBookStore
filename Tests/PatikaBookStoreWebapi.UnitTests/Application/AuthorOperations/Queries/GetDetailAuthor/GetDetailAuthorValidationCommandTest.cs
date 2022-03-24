using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthorDetail;
using TestSetup;
using Xunit;


namespace Application.AuthorOperations.Queries.GetDetailAuthor
{
    public class GetDetailAuthorValidationCommandTest:IClassFixture<CommonTestFicture>{
        [Theory]
        [InlineData(0)]
               

       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(int Id){
           //arrange
           GetAuthorDetailQuery query=new GetAuthorDetailQuery(null,null);
           query.AuthorId=Id;
           GetAuthorDetailQueryValidation validations=new GetAuthorDetailQueryValidation();
           var result=validations.Validate(query);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
      
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
              GetAuthorDetailQuery query=new GetAuthorDetailQuery(null,null);
               query.AuthorId=1;
           //act
         GetAuthorDetailQueryValidation validations=new GetAuthorDetailQueryValidation();
           var result=validations.Validate(query);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}