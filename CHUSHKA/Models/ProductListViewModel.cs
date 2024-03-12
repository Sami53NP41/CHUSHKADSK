namespace CHUSHKA.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
