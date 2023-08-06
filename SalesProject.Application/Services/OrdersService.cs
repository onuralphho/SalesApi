using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;

        public OrdersService(IMapper mapper, SalesDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var orders = _mapper.Map<List<OrderDto>>(await _context.Order.Include(x => x.Items).ToListAsync());
            var products = _mapper.Map<List<OrderProductDto>>(await _context.Product.ToListAsync());

            foreach (var order in orders)
            {
                var orderProducts = new List<OrderProductDto>();

                foreach (var item in order.Items)
                {
                    var product = products.Find(p => p.Sku == item.Sku);

                    if (product != null)
                    {
                        var productObj = new OrderProductDto
                        {
                            Name = product.Name,
                            Price = product.Price,
                            Quantity = item.Quantity,
                            Sku = item.Sku,
                        };
                        orderProducts.Add(productObj);
                    }
                }

                order.Items = orderProducts;
            }

            return orders;
        }
    }
}
