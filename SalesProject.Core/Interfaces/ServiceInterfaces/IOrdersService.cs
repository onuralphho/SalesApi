using SalesProject.Models.Cart;

namespace SalesProject.Core.Interfaces.ServiceInterfaces
{
    public interface IOrdersService
    {
        Task<List<OrderDto>> GetOrders();
    }
}
