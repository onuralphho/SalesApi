
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.RepostoryInterfaces;
using SalesProject.Entities;

namespace SalesProject.Domain.Repositories
{
    public class OrdersRepository: IOrdersRepository
    {
        private readonly SalesDbContext _context;

        public OrdersRepository(SalesDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAllOrdersWithItemsAsync()
        {
            return await _context.Order.Include(x => x.Items).ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }
    }
}
