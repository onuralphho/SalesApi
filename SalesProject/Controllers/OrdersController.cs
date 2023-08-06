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
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
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
                return null; //TODO: Create a new response object that carries error message!!
            }

        }

        [HttpPost("AddOrder")]
        public async Task<ActionResult> AddOrder(OrderDto order)
        {
            var response = await _orderService.AddOrder(order);

            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
