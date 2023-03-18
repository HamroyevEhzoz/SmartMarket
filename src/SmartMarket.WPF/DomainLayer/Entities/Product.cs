namespace SmartMarket.WPF.DomainLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int TotalAmount { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
