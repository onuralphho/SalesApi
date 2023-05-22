namespace SalesProject.Models.Campaign.DTO
{
    public class CampaignDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DiscountValue { get; set; }
    }
}
