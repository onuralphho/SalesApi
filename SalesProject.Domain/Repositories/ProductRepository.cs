using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.RepositoryInterfaces;
using SalesProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesDbContext _context;

        public ProductRepository(SalesDbContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetAllProductsWithCampaignAsync()
        {
            return await _context.Product
              .Include(p => p.ActiveCampaign)
              .ToListAsync();
        }

        public async Task<Product> GetProductDetailsAsync(string sku)
        {
            return await _context.Product
               .Include(p => p.ActiveCampaign)
               .FirstOrDefaultAsync(x => x.Sku == sku);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Product.Add(product);

            await _context.SaveChangesAsync();

            return await _context.Product
                .Include(p => p.ActiveCampaign)
                .SingleOrDefaultAsync(p => p.Id == product.Id);
        }
    }
}
