using System;
using AutoMapper;
using FluentAssertions;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.UpdateBook;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using TestSetup;
using Xunit;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;

namespace Application.BookOperations.Command.UpdateBook
{
    public class UpdateBookCommandValidatorTest:IClassFixture<CommonTestFicture>
    {
        [Theory]
        [InlineData("Lord Of Rings", 0)]//dısardan veri data alıyoruz bu teory ile 9 Inline demek 9 test demek
        [InlineData("", 0)]
        [InlineData("", 1)]
        [InlineData("Lord", 0)]


        public void WhenInvalidInputIsAreGiven_Validator_ShouldBeReturnErorrs(string title, int genreId)
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateViewModel()
            {
                Title = title,
                GenreId = genreId
            };
              command.BookId=2;
            //act
            UpdateBookCommandValidator validations = new UpdateBookCommandValidator();
            var result = validations.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
       public void WhenTittleIsFour_Validator_ShouldBeReturnError()
       {
             UpdateBookCommand command=new UpdateBookCommand(null);
           command.Model= new UpdateViewModel(){
               Title="Lr",
               GenreId=1
           };
        
         command.BookId=2;
           //act
           UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().BeGreaterThan(0);
       }
        [Fact] //happypaddıng
       public void WhenValidInputsAreGiven_VAlidator_ShouldNotBeReturnError()
       {
             UpdateBookCommand command=new UpdateBookCommand(null);
           command.Model= new UpdateViewModel(){
               Title="Lord Of The Ring",
               GenreId=1
           };
           command.BookId=2;
           //act
           UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
           var result=validations.Validate(command);
           //assert
           result.Errors.Count.Should().Be(0);
       }
    }
       
        
    }
