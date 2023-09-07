using back.Data;
using back.Model;
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


        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductoRequest addProductoRequest)
        {
            var product = new Producto()
            {
                id = Guid.NewGuid(),
                codigo = addProductoRequest.codigo,
                descripcion = addProductoRequest.descripcion,
                listaDePrecios = addProductoRequest.listaDePrecios,
                imagen = addProductoRequest.imagen,
                productoParaLaVenta = addProductoRequest.productoParaLaVenta,
                porcentajeIva = addProductoRequest.porcentajeIva
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductoRequest updateProductoRequest)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product != null)
            {

                product.codigo = updateProductoRequest.codigo;
                product.descripcion = updateProductoRequest.descripcion;
                product.listaDePrecios = updateProductoRequest.listaDePrecios;
                product.imagen = updateProductoRequest.imagen;
                product.productoParaLaVenta = updateProductoRequest.productoParaLaVenta;
                product.porcentajeIva = updateProductoRequest.porcentajeIva;

                dbContext.SaveChangesAsync();

                return Ok(product);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product != null)
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }

    }
}
