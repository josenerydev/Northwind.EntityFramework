namespace Northwind.Domain.Sales
{
    public class Shipper : AggregateRoot
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}