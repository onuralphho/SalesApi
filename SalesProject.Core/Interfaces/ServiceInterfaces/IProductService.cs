using SalesProject.Models.Product.Request;
using SalesProject.Models.Product.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Core.Interfaces.ServiceInterfaces
{
    public interface IProductService
    {
        Task<List<ProductGetAllResponse>> GetProducts();
        Task<ProductGetAllResponse> GetDetail(string sku);
        Task<ProductAddProductResponse> AddProduct(ProductAddRequest reqbody);
    }
}
