using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;

namespace MyAppMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Dữ liệu mẫu
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 600000, CreatedAt = new DateTime(2020, 12, 25), Image = "images/img1.jpg" },
                new Product { Id = 2, Name = "Product 2", Price = 700000, CreatedAt = new DateTime(2020, 12, 25), Image = "images/img2.jpg" },
                new Product { Id = 3, Name = "Product 3", Price = 550000, CreatedAt = new DateTime(2020, 12, 25), Image = "/images/p3.png" },
                new Product { Id = 4, Name = "Product 4", Price = 650000, CreatedAt = new DateTime(2020, 12, 25), Image = "/images/p4.png" },
            };

            return View(products);
        }
    }
}

