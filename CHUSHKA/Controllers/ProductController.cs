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
        public IActionResult AdminHome() //Index
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAdmin()//Create
        {
            var model = new ProductViewModel();
            return View(model);
        }
        [Authorize]
       
        public IActionResult CreateAdmin(ProductViewModel model) //Create
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

        public IActionResult DeleteProductAdmin(int id) //Delete product
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
        public IActionResult DeleteButton(int id) //Delete product button
        {
            var product = db.Products.Where(s => s.Id == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return this.RedirectToAction("AdminHome");
        }
        public IActionResult AllOrdersAdmin(OrderViewModel mdl) //All Orders
        {
            var Products = db.Products.Select(d=>d)
            var model = new ProductViewModel {
                OrderID = mdl.Id,
                OrderDTime = mdl.OrderOn
            };
            return View();
        }
        public IActionResult EditAdmin(int id) //Update
        {
            var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
            var model = new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductType = product.ProductType
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult EditAdmin(ProductViewModel model) //Update
        {
            var product = db.Products.Where(x => x.Id == model.Id).FirstOrDefault();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ProductType = model.ProductType;
            db.SaveChanges();
            return RedirectToAction("AdminHome");
        
        }
        
    }
     
}
