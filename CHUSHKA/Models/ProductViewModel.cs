namespace CHUSHKA.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int ProductType { get; set; }

        public string[] ProductTypes = new string[] { "Food", "Domestic", "Health",
            "Cosmetic", "Other" };
        public int OrderID { get; set; }
        public DateTime OrderDTime { get; set; }

    }
}
