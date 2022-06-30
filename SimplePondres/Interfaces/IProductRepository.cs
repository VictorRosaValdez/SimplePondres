using Microsoft.AspNetCore.Mvc;
using SimplePondres.Models;

namespace SimplePondres.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Abstract method to get all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        Task<ActionResult<IEnumerable<Product>>> GetProductsAsync();

        /// <summary>
        /// Abstract method to get a product by Id.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <returns>The product object.</returns>
        Task<ActionResult<Product>> GetProductAsync(int id);
    }
}
