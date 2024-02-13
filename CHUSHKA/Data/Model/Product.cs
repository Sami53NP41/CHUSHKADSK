namespace CHUSHKA.Data.Model
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int ProductType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
