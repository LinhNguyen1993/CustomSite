using CustomSite.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private SiteContext _context;
        public ProductController(IUnitOfWork unitOfWork, SiteContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult getProducts()
        {
            //var products = _unitOfWork.Products.GetAll();
            var products = _context.Products.AsNoTracking();

            return Ok();
        }
    }
}