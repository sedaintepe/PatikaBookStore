using System;
using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.UserOperations.Commands.CreateUser
{
    public class CreateUserCommanValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommanValidation()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3);
            RuleFor(command => command.Model.SurName).MinimumLength(3);
            RuleFor(command=>command.Model.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");
            RuleFor(command => command.Model.Password).MinimumLength(3);
        }
    }
}