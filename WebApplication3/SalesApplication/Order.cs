namespace WebApplication3.Sales
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
