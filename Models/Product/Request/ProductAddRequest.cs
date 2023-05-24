using SalesProject.Models.Campaign.DTO;

namespace SalesProject.Models.Product.Request
{
    public class ProductAddRequest
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? CampaignId { get; set; }

    }
}
