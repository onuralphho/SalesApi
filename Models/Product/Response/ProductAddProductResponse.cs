using SalesProject.Models.Campaign.DTO;

namespace SalesProject.Models.Product.Response
{
    public class ProductAddProductResponse
    {
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int? DiscountPrice { get; set; }
        public int StockCount { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public CampaignDto ActiveCampaign { get; set; }

    }
}
