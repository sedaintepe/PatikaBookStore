using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.commands.UpdateGenre
{
    public class UpdateGenreCommandsValidator:AbstractValidator<UpdateGenreCommands>
    {
      public UpdateGenreCommandsValidator()
      {
         // RuleFor(command=>command.GenreId).GreaterThan(0);
          RuleFor(command=>command.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim()!=string.Empty);

      }
    }
}