using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Mapping;
using CoffeeShopAPI.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CoffeeShopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CoffeeShopContext _context;

        public ProductsController(CoffeeShopContext context)
        {
            _context = context;
        }

        // GET: /Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSummaryDto>>> GetProducts()
        {
            return await _context.Products.Include(product => product.Category).Select(product => product.ToSummaryDto()).ToListAsync();
        }

        // GET: /Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSummaryDto>> GetProduct(int id)
        {
            var product = await _context.Products.Include(prod => prod.Category).FirstOrDefaultAsync(prod => prod.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product.ToSummaryDto();
        }

        // PUT: Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product.ToEntity(id));
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductDto product)
        {
            Product productToAdd = product.ToEntity();
            _context.Products.Add(productToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = productToAdd.Id }, productToAdd.ToDetailsDto());
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
