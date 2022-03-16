using System;
using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1
{
    public class CreateBookVCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookVCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}