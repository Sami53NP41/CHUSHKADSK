using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreteRole(CreateRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationRole role = new ApplicationRole
            {
                Name = model.RoleName,
            };
            //var result = await roleManager.CreateAsync(role); //Add in database
            //if (result.Succeeded)
            //{
            //    return Redirect("/");
            //}
            //else
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError("", error.ToString());
            //    }
            //}
            return View();
        }
    }
}
