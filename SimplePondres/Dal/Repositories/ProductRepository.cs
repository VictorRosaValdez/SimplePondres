using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePondres.Interfaces;
using SimplePondres.Models;

namespace SimplePondres.Dal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly SimplePondresDbContext _context;

        /// <summary>
        /// Constructor for the ProductRepository.
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(SimplePondresDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a product by Id
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>A product object</returns>
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);

            return product;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>A list of products</returns>
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var product = await _context.Product.ToListAsync();

            return product;
        }
    }
}
