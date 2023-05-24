using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Entities;
using SalesProject.Models.Product.Request;
using SalesProject.Models.Product.Response;

namespace SalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(SalesDbContext salesDbContext, IMapper mapper)
        {
            _context = salesDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ProductGetAllResponse>> GetProducts()
        {

            var products = await _context.Product
                .Include(p => p.ActiveCampaign)
                .ToListAsync();

            return products.Select(product =>
            {
                if (product.ActiveCampaign != null)
                {
                    product.DiscountedPrice = product.Price - (product.Price * product.ActiveCampaign.DiscountValue) / 100;
                }
                return _mapper.Map<ProductGetAllResponse>(product);
            }).ToList();

        }

        [HttpGet]
        [Route("{sku}")]
        public async Task<ProductGetAllResponse> GetDetail(string sku)
        {
            var product = await _context.Product
                .Include(p => p.ActiveCampaign)
                .SingleOrDefaultAsync(x => x.Sku == sku);

            if (product.ActiveCampaign != null)
            {
                product.DiscountedPrice = product.Price - (product.Price * product.ActiveCampaign.DiscountValue) / 100;

            }
            return _mapper.Map<ProductGetAllResponse>(product);
        }

        [HttpPost("AddProduct")]
        public async Task<ProductAddProductResponse> AddProduct(ProductAddRequest reqbody)
        {
            var newProduct = new Product
            {
                Sku = reqbody.Sku,
                Name = reqbody.Name,
                Description = reqbody.Description,
                CreatedTime = DateTime.UtcNow,
                Price = reqbody.Price,
                ActiveCampaignId = reqbody.CampaignId

            };

            _context.Product.Add(newProduct);

            await _context.SaveChangesAsync();

            newProduct = await _context.Product
                .Include(p => p.ActiveCampaign)
                .SingleOrDefaultAsync(p => p.Id == newProduct.Id);

            return _mapper.Map<ProductAddProductResponse>(newProduct);
        }
    }
}
