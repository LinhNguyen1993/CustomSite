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
        private readonly IUnitOfWork _unitOfWork;
        public SampleDataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;         
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
                    ProductPrice = 1000,
                    ProductDescription = "this is BMW",
                    Manufactory = "EU"
                },
                new Product{
                    ProductName = "Mercedes",
                    ProductPrice = 1000,
                    ProductDescription = "this is Mercedes",
                    Manufactory = "EU"
                },
            };
            _unitOfWork.Categories.Add(c);
            _unitOfWork.SaveChange();
        }
    }
}
