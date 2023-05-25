using SalesProject.Models.Campaign.DTO;

namespace SalesProject.Models.Product.Request
{
    public class ProductAddRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockCount { get; set; } = 0;
        public int? CampaignId { get; set; }

    }
}
