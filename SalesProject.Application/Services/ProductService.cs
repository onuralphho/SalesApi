using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Core.Interfaces.RepositoryInterfaces;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Entities;
using SalesProject.Exceptions;
using SalesProject.Models.Product.Request;
using SalesProject.Models.Product.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductGetAllResponse>> GetProducts()
        {
            var products = await _productRepository.GetAllProductsWithCampaignAsync();

            return products.Select(product =>
            {
                if (product.ActiveCampaign != null)
                {
                    product.DiscountedPrice = product.Price - (product.Price * product.ActiveCampaign.DiscountValue) / 100;
                }
                return _mapper.Map<ProductGetAllResponse>(product);
            }).ToList();
        }

        public async Task<ProductGetAllResponse> GetDetail(string sku)
        {
            var product = await _productRepository.GetProductDetailsAsync(sku);

            if (product.ActiveCampaign != null)
            {
                product.DiscountedPrice = product.Price - (product.Price * product.ActiveCampaign.DiscountValue) / 100;

            }
            return _mapper.Map<ProductGetAllResponse>(product);
        }

        public async Task<ProductAddProductResponse> AddProduct(ProductAddRequest reqbody)
        {
            if (reqbody.Name.Length == 0)
            {
                throw new BadRequestException("Name section should not be empty", "name_error");
            }

            var newProduct = new Product
            {
                Sku = $"{reqbody.Name.Trim()}{Guid.NewGuid()}",
                Name = reqbody.Name,
                Description = reqbody.Description,
                CreatedTime = DateTime.UtcNow,
                Price = reqbody.Price,
                StockCount = reqbody.StockCount,
                ActiveCampaignId = reqbody.CampaignId
            };

            newProduct = await _productRepository.AddProductAsync(newProduct);

            return _mapper.Map<ProductAddProductResponse>(newProduct);
        }
    }
}
