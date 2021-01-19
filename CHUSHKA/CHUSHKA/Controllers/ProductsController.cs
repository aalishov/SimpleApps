using CHUSHKA.Data;
using CHUSHKA.Data.Models;
using CHUSHKA.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }
            Data.Models.Type type = dbContext.Types.FirstOrDefault(x => x.Name == inputModel.Type);

            Product product = new Product()
            {
                Name = inputModel.Name,
                Price = inputModel.Price,
                Type = type,
                Description = inputModel.Description
            };

            this.dbContext.Products.Add(product);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Users"); ;
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var model = this.dbContext.Products
                .Select(x => new DetailsProductViewModel()
                {
                    Id=x.Id,
                    Name = x.Name,
                    Price = x.Price.ToString("0.00"),
                    Type = x.Type.Name,
                    Description = x.Description
                })
                .FirstOrDefault(x => x.Id == id);
            return this.View(model);
        }

        public IActionResult AdminDetails(string id)
        {
            var model = this.dbContext.Products
               .Select(x => new DetailsProductViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Price = x.Price.ToString("0.00"),
                   Type = x.Type.Name,
                   Description = x.Description
               })
               .FirstOrDefault(x => x.Id == id);
            return this.View(model);
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
