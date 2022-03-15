using FluentValidation;

namespace PatikaBookStoreWebapi.BookOperations.GetBookDetail1{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidator(){
            RuleFor(query=>query.BookId).GreaterThan(0);
        }
    }
}