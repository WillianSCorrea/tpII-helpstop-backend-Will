using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Application.Products.Queries;
using MediatR;

namespace HelpApp.Application.Products.Handler
{
    public class GetProductsQueryHandler : IRequest<IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts();
        }
    }
}