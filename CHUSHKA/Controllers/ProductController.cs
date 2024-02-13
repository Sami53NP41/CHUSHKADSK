using CHUSHKA.Data;
using CHUSHKA.Data.Model;
using Microsoft.AspNetCore.Mvc;
using CHUSHKA.Models;

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
        public IActionResult Index()
        {
            var model = new ProductViewModel();

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ProductType = model.ProductType,
            };
            db.Products.Add(product);
            db.SaveChanges();
            return View(model);
        }

    }
}
