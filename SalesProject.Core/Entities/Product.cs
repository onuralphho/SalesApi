using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace SalesProject.Entities
{
    [Index(nameof(Sku), IsUnique = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }
        public int StockCount { get; set; } = 0;
        public int? DiscountedPrice { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        [ForeignKey("ActiveCampaign")]
        public int? ActiveCampaignId { get; set; }
        public Campaign? ActiveCampaign { get; set; }
    }
}
