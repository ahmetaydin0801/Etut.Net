

using Etut.Application.Queries;
using FluentValidation;

namespace CQRSExample.Application.Validators;

    public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsQueryValidator()
        {
            // Add validation rules if needed
        }
    }
