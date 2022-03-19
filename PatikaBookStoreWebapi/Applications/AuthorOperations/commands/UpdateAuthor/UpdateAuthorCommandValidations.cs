using System;
using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.AuthorOperations.commands.UpdateAuthor{
    public class UpdateAuthorCommandValidations: AbstractValidator<UpdateAuthorCommand>{
        public UpdateAuthorCommandValidations(){
            RuleFor(command=>command.AuthorId).GreaterThan(0);
            RuleFor(command=>command.Model.BookId).NotEmpty().GreaterThan(0);
            RuleFor(command=>command.Model.Name).MinimumLength(3).When(x=>x.Model.Name.Trim()!=string.Empty);
            
        }
    }
}