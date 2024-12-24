

using Etut.Application.Queries;
using FluentValidation;

namespace CQRSExample.Application.Validators;

    public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsQueryValidator()
        {
            RuleFor(query => query)
                .NotNull()
                .WithMessage("Query cannot be null.");
        }
    }
