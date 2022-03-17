using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.commands.CreateGenre
{
    public class CreateGenreCommandsValidator:AbstractValidator<CreateGenreCommands>
    {
      public CreateGenreCommandsValidator()
      {
          RuleFor(command=>command._model.Name).NotEmpty().MinimumLength(4);
      }
    }
}