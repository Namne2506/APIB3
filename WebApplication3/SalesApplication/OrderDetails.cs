namespace WebApplication3.Sales
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
