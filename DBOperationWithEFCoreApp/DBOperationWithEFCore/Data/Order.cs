namespace DBOperationWithEFCore.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Amount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
