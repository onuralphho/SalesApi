namespace SalesProject.Models.Cart
{
    public class OrderProductDto
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Name { get; set; }
    }
}
