using CHUSHKA.Data;
using CHUSHKA.Data.Model;
using Microsoft.AspNetCore.Mvc;
using CHUSHKA.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

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
        //[Authorize(Roles = "Administrator")]
        public IActionResult AdminHome() //Index/ read
        {
            var Products = db.Products.Select(d => new ProductViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
            }).ToList();
            
            return View(Products);

        }

        [HttpGet]
        //[Authorize(Roles = "Administrator")]
        public IActionResult CreateAdmin()//Create
        {
            var model = new ProductViewModel();
            return View(model);
        }
        //[Authorize(Roles = "Administrator")]

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
        //[Authorize(Roles = "Administrator")]
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
       // [Authorize(Roles = "Administrator")]
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
        //[Authorize(Roles = "Administrator")]
        public IActionResult AllOrdersAdmin() //All Orders
        {
            var Products = db.Orders.Select(d => new ProductViewModel
            {
                OrderID = d.Id,
                OrderDTime = d.OrderOn,              
            }).ToList();

            return View(Products);
        }
        //[Authorize(Roles = "Administrator")]


        [HttpPost]

        //[Authorize(Roles = "Administrator")]
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
