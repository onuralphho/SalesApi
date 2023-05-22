using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesProject.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [ForeignKey("ActiveCampaign")]
        public int? ActiveCampaignId { get; set; }
        public Campaign ActiveCampaign { get; set; }
    }
}
