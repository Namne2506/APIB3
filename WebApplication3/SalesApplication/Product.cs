namespace WebApplication3.Sales
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }


        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
