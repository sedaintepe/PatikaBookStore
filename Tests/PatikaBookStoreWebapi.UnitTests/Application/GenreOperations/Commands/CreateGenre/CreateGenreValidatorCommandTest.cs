using System;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.CreateGenre;
using TestSetup;
using Xunit;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreValidatorCommandTest:IClassFixture<CommonTestFicture>{
        [Theory]
        [InlineData("")]
       

       public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(string Name){
           //arrange
           CreateGenreCommands command=new CreateGenreCommands(null);
           command._model= new CreateGenreModel(){
               Name=Name,

           };
           //act
           CreateGenreCommandsValidator validations=new CreateGenreCommandsValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);

       }
       [Fact]
        public void WhenValidNameAreGivenFour_Validator_ShouldNotBeReturnError()
       {
          CreateGenreCommands command=new CreateGenreCommands(null);
            command._model= new CreateGenreModel(){
               Name="Hay",
           };
           //act
           CreateGenreCommandsValidator validations=new CreateGenreCommandsValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);
       }

      
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
       {
          CreateGenreCommands command=new CreateGenreCommands(null);
            command._model= new CreateGenreModel(){
               Name="Harry",
           };
           //act
           CreateGenreCommandsValidator validations=new CreateGenreCommandsValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
        
    }
}