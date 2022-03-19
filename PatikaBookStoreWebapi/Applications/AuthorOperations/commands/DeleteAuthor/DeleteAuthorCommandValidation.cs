
using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.AuthorOperations.commands.DeleteAuthor{
    public class DeleteAuthorCommandValidation: AbstractValidator<DeleteAuthorCommand>{
        public DeleteAuthorCommandValidation(){
            RuleFor(command=>command.AuthorId).GreaterThan(0);
        }
    }
}