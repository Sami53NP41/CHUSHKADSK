using CHUSHKA.Data;
using CHUSHKA.Data.Model;
using Microsoft.AspNetCore.Mvc;
using CHUSHKA.Models;
using Microsoft.AspNetCore.Authorization;

namespace CHUSHKA.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db;
        private IWebHostEnvironment webHostEnvironment;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult AdminHome()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateAdmin()
        {
            var model = new ProductViewModel();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateAdmin(ProductViewModel model)
        {
            var product = new Product
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                ProductType = model.ProductType,
            };

            db.Products.Add(product);
            db.SaveChanges();

            return this.RedirectToAction("AdminHome");
        }
        public IActionResult ProductDetailsAdmin(int id)
        {
            var model = db.Products.Where(x => id == x.Id).Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ProductType = x.ProductType
            }).FirstOrDefault();
            return this.View(model);
        }

        public IActionResult DeleteProductAdmin(int id) 
        {
            var model = db.Products.Where(x => id == x.Id).Select(x=>new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ProductType = x.ProductType 
            }).FirstOrDefault();
            return this.View(model);
        }
        public IActionResult DeleteButton(int id)
        {
            var product = db.Products.Where(s => s.Id == id).FirstOrDefault(); 
            db.Products.Remove(product);
            db.SaveChanges();
            return this.RedirectToAction("AdminHome");
        }
    }
     
}
