using Etut.Domain.Entities;
using MediatR;

namespace Etut.Application.Queries;

public record GetProductsQuery : IRequest<List<Product>>;