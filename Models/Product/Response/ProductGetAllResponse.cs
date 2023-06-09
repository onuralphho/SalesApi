﻿using SalesProject.Entities;
using SalesProject.Models.Campaign.DTO;

namespace SalesProject.Models.Product.Response
{
    public class ProductGetAllResponse
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int StockCount { get; set; }
        public int? DiscountedPrice { get; set; }
        public DateTime CreatedTime { get; set; }
        public CampaignDto ActiveCampaign { get; set; }

    }
}
