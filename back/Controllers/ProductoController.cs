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
        public IActionResult UpdateProduct([FromRoute] Guid id, UpdateProductoRequest updateProductoRequest)
        {
            var product = dbContext.Products.Find(id);

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

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            var product = dbContext.Products.FindAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            var product =  dbContext.Products.FindAsync(id);

            if (product != null)
            {
                dbContext.Remove(product);
                dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }

    }
}
