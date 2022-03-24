using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.DeleteAuthor;
using TestSetup;
using Xunit;


namespace Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorValidationsCommandTest:IClassFixture<CommonTestFicture>{
        
        [Theory]
        [InlineData(0)]
   
       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(int Id){
           //arrange
         DeleteAuthorCommand command=new DeleteAuthorCommand(null);
         command.AuthorId=Id;
           //act
           DeleteAuthorCommandValidation validations=new DeleteAuthorCommandValidation();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
     
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
        DeleteAuthorCommand command=new DeleteAuthorCommand(null);
         command.AuthorId=2;
           //act
            DeleteAuthorCommandValidation validations=new DeleteAuthorCommandValidation();
            var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}