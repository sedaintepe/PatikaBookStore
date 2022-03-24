using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.UpdateAuthor;
using TestSetup;
using Xunit;

namespace Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommandValidationTest:IClassFixture<CommonTestFicture>
    {
        [Theory]
        [InlineData("Steve",0)]
        [InlineData("",0)]
        [InlineData("",1)]
       

        public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(string name, int bookId)
        {
            //arrange
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new AuthorUpdateViewModel()
            {
                Name = name,
                BookId = bookId
            };
            
            //act
            UpdateAuthorCommandValidations validations = new UpdateAuthorCommandValidations();
            var result = validations.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
       public void WhenNameIsThree_Validator_ShouldBeReturnError()
       {
             UpdateAuthorCommand command = new UpdateAuthorCommand(null);
             command.Model = new AuthorUpdateViewModel()
            {
                Name = "St",
                BookId = 1
            };
        
         command.AuthorId=2;
           //act
           UpdateAuthorCommandValidations validations = new UpdateAuthorCommandValidations();
            var result = validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);
       }
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
             UpdateAuthorCommand command = new UpdateAuthorCommand(null);
             command.Model = new AuthorUpdateViewModel()
            {
                Name = "Steve",
                BookId = 1
            };
        
         command.AuthorId=2;
           //act
             UpdateAuthorCommandValidations validations = new UpdateAuthorCommandValidations();
            var result = validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
    }
       
        
    }
