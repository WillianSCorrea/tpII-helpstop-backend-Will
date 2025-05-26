using HelpApp
    .Domain.Entities;
using HelpApp.Domain.Interfaces;
using MediatR;
using HelpApp.Application.Products.Commands;


namespace HelpApp.Application.Products.Handler
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image)
            if(product == null)
            {
                throw new ArgumentNullException($"Product cannot be null");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.Create(product);
            }

            
    }
    
    }
}
