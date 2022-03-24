using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook;
using TestSetup;
using Xunit;


namespace Application.BookOperations.Command.DeleteBook
{
    public class DeleteBookCommanValidatorTest:IClassFixture<CommonTestFicture>{
        
        [Theory]
        [InlineData(0)]
   
       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(int Id){
           //arrange
         DeleteBookCommand command=new DeleteBookCommand(null);
         command.BookId=Id;
           //act
           DeleteBookCommandValidator validations=new DeleteBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
     
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
             DeleteBookCommand command=new DeleteBookCommand(null);
           command.BookId= 2;
           //act
           DeleteBookCommandValidator validations=new DeleteBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}