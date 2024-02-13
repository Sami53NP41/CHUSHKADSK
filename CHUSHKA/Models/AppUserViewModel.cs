using CHUSHKA.Data.Model;

namespace CHUSHKA.Models
{
    public class AppUserViewModel
    {
        public string FullName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
