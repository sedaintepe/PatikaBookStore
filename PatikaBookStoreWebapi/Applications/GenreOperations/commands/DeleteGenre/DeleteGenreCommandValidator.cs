using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.commands.DeleteGenre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
      public DeleteGenreCommandValidator()
      {
          RuleFor(command=>command.GenreId).GreaterThan(0);
      }
    }
}