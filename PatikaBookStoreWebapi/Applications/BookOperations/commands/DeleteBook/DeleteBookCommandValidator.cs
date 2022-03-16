using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {

        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }



    }

}





