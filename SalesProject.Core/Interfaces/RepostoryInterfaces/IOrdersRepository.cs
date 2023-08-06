using SalesProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Core.Interfaces.RepostoryInterfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrdersWithItemsAsync();
        Task<Order> AddOrderAsync(Order newOrder);
    }
}
