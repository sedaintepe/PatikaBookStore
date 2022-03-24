using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthorDetail;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail;
using TestSetup;
using Xunit;


namespace Application.GenreOperations.Queries.GetDetailGenre
{
    public class GetDetailQueryGenreValidationTest:IClassFixture<CommonTestFicture>{
        [Theory]
        [InlineData(0)]
               

       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(int Id){
           //arrange
           GetGenreDetailQuery query=new GetGenreDetailQuery(null,null);
           query.GenreId=Id;
           GetGenreDetailQueryValidator validations=new GetGenreDetailQueryValidator();
           var result=validations.Validate(query);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
      
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
              GetGenreDetailQuery query=new GetGenreDetailQuery(null,null);
               query.GenreId=1;
           //act
         GetGenreDetailQueryValidator validations=new GetGenreDetailQueryValidator();
           var result=validations.Validate(query);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}