using SalesProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Models.Cart
{
    public class OrderDto
    {
        public string? Address { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Name { get; set; }       
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public List<OrderProductDto> Items { get; set; }
    }
}
