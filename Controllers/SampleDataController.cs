using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSite.Core;
using CustomSite.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomSite.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IEntityBaseRepository<Category> _repository;
        public SampleDataController(IEntityBaseRepository<Category> repository)
        {
            _repository = repository;         
            add();   
        }
        
        public void add()
        {
            var c = new Category();
            c.CategoryName = "Car";
            c.CategoryDescription = "this is car";
            c.Products = new List<Product>()
            {
                new Product{
                    ProductName = "BMW",
                    ProductPrice = "100000",
                    ProductDescription = "this is BMW",
                    Manufactory = "EU"
                },
                new Product{
                    ProductName = "Mercedes",
                    ProductPrice = "100000",
                    ProductDescription = "this is Mercedes",
                    Manufactory = "EU"
                },
            };
            _repository.Add(c);
            _repository.SaveChage();
        }
    }
}
