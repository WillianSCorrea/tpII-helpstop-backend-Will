using AutoMapper;
using HelpApp.Application.DTOs;
using HelpApp.Application.Interfaces;
using HelpApp.Domain.Interfaces;
using HelpApp.Domain.Entities;

namespace HelpApp.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductService (IProductRepository productRepository, IMapper mapper)
        {
            _categoryRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _categoryRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);

        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _categoryRepository.Create(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _categoryRepository.Update(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(productEntity);
        }
    }
}
