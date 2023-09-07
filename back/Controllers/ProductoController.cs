using back.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class ProductoControlador : Controller

    {
        private readonly ProductoAPIDbContext dbContext;

        public ProductoControlador(ProductoAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(dbContext.Products.ToListAsync());
        }

    }
}
