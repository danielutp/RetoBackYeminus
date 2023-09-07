using back.Data;
using back.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers
{

    [ApiController]
    [EnableCors("ReglasCors")]
    [Route("api/controller")]
    public class ProductoControlador : Controller

    {
        private readonly ProductoAPIDbContext dbContext;

        public ProductoControlador(ProductoAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(dbContext.Products.ToList());
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductoRequest addProductoRequest)
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

             dbContext.Products.Add(product);
             dbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductoRequest updateProductRequest)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product != null)
            {

                product.codigo = updateProductRequest.codigo;
                product.descripcion = updateProductRequest.descripcion;
                product.listaDePrecios = updateProductRequest.listaDePrecios;
                product.imagen = updateProductRequest.imagen;
                product.productoParaLaVenta = updateProductRequest.productoParaLaVenta;
                product.porcentajeIva = updateProductRequest.porcentajeIva;

                dbContext.SaveChangesAsync();

                return Ok(product);
            }
            return NotFound();

        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product != null)
            {
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
