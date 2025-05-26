using HelpApp.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace HelpApp.Application.Products.Queries
{
    internal class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
