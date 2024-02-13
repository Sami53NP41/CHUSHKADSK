using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Data.Model
{
    public class AppUser : IdentityUser
    {
      public AppUser()
      {
        this.Orders = new HashSet<Order>();
      }
      public string FullName { get; set; }
      public virtual ICollection<Order> Orders { get; set; }
    }

}
