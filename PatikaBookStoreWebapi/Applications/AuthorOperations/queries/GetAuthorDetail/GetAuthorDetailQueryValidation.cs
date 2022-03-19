using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthorDetail{
    public class GetAuthorDetailQueryValidation: AbstractValidator<GetAuthorDetailQuery>{
        public GetAuthorDetailQueryValidation(){
            RuleFor(query=>query.AuthorId).GreaterThan(0);
        }
    }
}