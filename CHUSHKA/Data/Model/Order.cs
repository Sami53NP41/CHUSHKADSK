namespace CHUSHKA.Data.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser UserApp { get; set; }
        public DateTime OrderOn { get; set; }
    }
}
