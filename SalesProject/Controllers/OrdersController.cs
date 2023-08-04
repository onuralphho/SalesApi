using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Entities;
using System.Linq;
using SalesProject.Models.Cart;
using SalesProject.Models.Product.Response;

namespace SalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper, SalesDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet("GetOrders")]
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

        [HttpPost("AddOrder")]
        public async Task<ActionResult> AddOrder(OrderDto order)
        {
            var newProducts = new List<CartProduct>();


            foreach (var item in order.Items)
            {
                var product = await _context.Product.FirstOrDefaultAsync(x => x.Sku == item.Sku);
                product.StockCount -= item.Quantity;
                newProducts.Add(new CartProduct
                {
                    Quantity = item.Quantity,
                    Sku = item.Sku,
                });
            }

            var newOrder = new Order
            {
                OrderId = new Guid(),
                Address = order.Address,
                PaymentMethod = order.PaymentMethod,
                Items = newProducts,
                Name = "John",//todo: Fix the dummy datas
                Surname = "Doe",
                PhoneNumber = "05313781155"
            };

            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<OrderDto>(newOrder));
        }


    }
}
