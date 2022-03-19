

using System;
using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor{
    public class CreateAuthorCommandValidation: AbstractValidator<CreateAuthorCommand>{
        public CreateAuthorCommandValidation(){
           RuleFor(command=>command.Model.Name).NotEmpty().MinimumLength(3);
           RuleFor(command=>command.Model.Surname).NotEmpty().MinimumLength(3);
           RuleFor(command=>command.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
           RuleFor(command=>command.Model.BookId).GreaterThan(0);


        }
    }
}