using FluentValidation;

namespace PatikaBookStoreWebapi.BookOperations.GetBookDetail1{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidator(){
            RuleFor(command=>command.BookId).GreaterThan(0);
        }
    }
}