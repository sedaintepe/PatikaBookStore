using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.DeleteAuthor;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.DeleteGenre;
using TestSetup;
using Xunit;


namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidationTest:IClassFixture<CommonTestFicture>{
        
        [Theory]
        [InlineData(0)]
   
       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(int Id){
           //arrange
         DeleteGenreCommand command=new DeleteGenreCommand(null);
         command.GenreId=Id;
           //act
           DeleteGenreCommandValidator validations=new DeleteGenreCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
     
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
        DeleteGenreCommand command=new DeleteGenreCommand(null);
         command.GenreId=2;
           //act
            DeleteGenreCommandValidator validations=new DeleteGenreCommandValidator();
            var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}