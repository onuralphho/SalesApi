namespace SalesProject.Models.Cart
{
    public class OrderProductDto
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }
}
