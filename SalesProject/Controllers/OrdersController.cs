using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Entities;
using System.Linq;
using SalesProject.Models.Cart;
using SalesProject.Models.Product.Response;
using SalesProject.Core.Interfaces.ServiceInterfaces;

namespace SalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOrdersService _orderService;

        public OrdersController(IMapper mapper, SalesDbContext context, IOrdersService orderService)
        {
            _mapper = mapper;
            _context = context;
            _orderService = orderService;
        }


        [HttpGet("GetOrders")]
        public async Task<List<OrderDto>> GetOrders()
        {
            var response = await _orderService.GetOrders();

            if(response != null)
            {
                return response;
            }
            else
            {
                return null; //TODO: Create a new response object that carry messages!!
            }

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
