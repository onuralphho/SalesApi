using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.RepositoryInterfaces;
using SalesProject.Core.Interfaces.RepostoryInterfaces;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Entities;
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
       
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrdersService(IMapper mapper,IOrdersRepository orderRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderDto>> GetOrders()
        {

            var orders = _mapper.Map<List<OrderDto>>(await _orderRepository.GetAllOrdersWithItemsAsync());
            var products = _mapper.Map<List<OrderProductDto>>(await _productRepository.GetAllProductsWithCampaignAsync());

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

        public async Task<OrderDto> AddOrder(OrderDto orderRequest)
        {
            var newProducts = new List<CartProduct>();


            foreach (var item in orderRequest.Items)
            {
                var product = await _productRepository.GetProductDetailsAsync(item.Sku);
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
                Address = orderRequest.Address,
                PaymentMethod = orderRequest.PaymentMethod,
                Items = newProducts,
                Name = "John",//todo: Fix the dummy datas
                Surname = "Doe",
                PhoneNumber = "05313781155"
            };


            return _mapper.Map<OrderDto>(await _orderRepository.AddOrderAsync(newOrder));
        }
    }
}
