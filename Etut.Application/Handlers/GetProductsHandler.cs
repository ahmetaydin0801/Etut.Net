

using Etut.Application.Queries;
using Etut.Domain.Entities;
using MediatR;

namespace CQRSExample.Application.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A" },
                new Product { Id = 2, Name = "Product B" },
                new Product { Id = 3, Name = "Product C" }
            };

            return Task.FromResult(products);
        }
    }
}