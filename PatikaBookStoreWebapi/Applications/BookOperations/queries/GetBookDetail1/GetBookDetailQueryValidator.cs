using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidator(){
            RuleFor(query=>query.BookId).GreaterThan(0);
        }
    }
}