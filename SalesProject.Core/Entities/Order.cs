﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesProject.Entities
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public List<CartProduct> Items { get; set; }
    }
}
