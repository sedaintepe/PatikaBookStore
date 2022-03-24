using FluentAssertions;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.UpdateGenre;
using TestSetup;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidationTest:IClassFixture<CommonTestFicture>
    {
        // [Theory]

        // [InlineData("",true)]
     
      
     
        // public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(string name,bool isActive)
        // {
        //     //arrange
        //     UpdateGenreCommands command = new UpdateGenreCommands(null);
        //     command.Model = new UpdateGenreModel()
        //     {
        //         Name = name,
        //         IsActive=isActive
              
        //     };
     
        //     //act
        //     UpdateGenreCommandsValidator validations = new UpdateGenreCommandsValidator();
        //     var result = validations.Validate(command);
        //     //assert
        //     result.Errors.Count.Should().BeGreaterThan(0);

        // }

        [Fact]
       public void WhenNameIsFour_Validator_ShouldBeReturnError()
       {
             UpdateGenreCommands command = new UpdateGenreCommands(null);
             command.Model = new UpdateGenreModel()
            {
                Name = "St",
                IsActive=true
                
            };
        
         command.GenreId=2;
           //act
           UpdateGenreCommandsValidator validations = new UpdateGenreCommandsValidator();
            var result = validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);
       }
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
             UpdateGenreCommands command = new UpdateGenreCommands(null);
             command.Model = new UpdateGenreModel()
            {
                Name = "Yasam",
                IsActive=true
            };
        
         command.GenreId=2;
           //act
             UpdateGenreCommandsValidator validations = new UpdateGenreCommandsValidator();
            var result = validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
    }
       
        
    }
