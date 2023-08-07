using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Entities;
using SalesProject.Exceptions;
using SalesProject.Models.Product.Request;
using SalesProject.Models.Product.Response;

namespace SalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductGetAllResponse>> GetProducts()
        {
            var response = await _productService.GetProducts();

            if (response != null)
            {
                return response;
            }
            else
            {
                return null; //Create new Response Object
            }
        }

        [HttpGet]
        [Route("{sku}")]
        public async Task<ProductGetAllResponse> GetDetail(string sku)
        {
            var response = await _productService.GetDetail(sku);
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("AddProduct")]
        public async Task<ProductAddProductResponse> AddProduct(ProductAddRequest reqbody)
        {
            var response = await _productService.AddProduct(reqbody);
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        [Route("ResetProductCampaign/{sku}")]
        public async Task<ProductGetAllResponse> ResetProductCampaign(string sku)
        {
            var response = await _productService.ResetProductCampaign(sku);

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
