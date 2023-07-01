using SalesProject.Entities;

namespace SalesProject.Models.Cart
{
    public class OrderDto
    {
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public List<OrderProductDto> Items { get; set; }
    }
}
