namespace SalesProject.Models.Campaigns.Request
{
    public class CampaignAddRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DiscountValue { get; set; }
    }
}
