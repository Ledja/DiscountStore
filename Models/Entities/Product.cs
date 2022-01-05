namespace Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
