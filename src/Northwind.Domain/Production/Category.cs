namespace Northwind.Domain.Production
{
    public class Category : AggregateRoot
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}