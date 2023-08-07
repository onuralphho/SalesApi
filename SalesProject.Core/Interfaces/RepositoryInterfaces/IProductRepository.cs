using SalesProject.Entities;

namespace SalesProject.Core.Interfaces.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsWithCampaignAsync();
        Task<Product> GetProductDetailsAsync(string sku);
        Task<Product> AddProductAsync(Product product);
        Task<Product> ResetProductCampaignAsync(string sku);
    }
}
