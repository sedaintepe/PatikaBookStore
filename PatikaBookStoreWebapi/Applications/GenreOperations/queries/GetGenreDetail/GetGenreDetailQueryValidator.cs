using FluentValidation;

namespace PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>
    {
      public GetGenreDetailQueryValidator()
      {
          RuleFor(query=>query.GenreId).GreaterThan(0);
      }
    }
}