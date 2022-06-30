using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimplePondres.DTOs.ProductDTOs;
using SimplePondres.Interfaces;
using SimplePondres.Models;
using System.Net.Mime;

namespace SimplePondres.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProductController : ControllerBase
    {
        // Fields 
        private readonly IProductRepository _product;

        private readonly IMapper _mapper;

        public ProductController(IProductRepository product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;

        }

        // GET: api/products
        /// <summary>
        /// Get all products.
        /// </summary>
        /// <response code="200">Succesfully returns a product object.</response>
        /// <returns>A list of product objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetProducts()
        {
            // Instance of the domainProduct objects.
            var domainProduct = await _product.GetProductsAsync();

            // Map domainProduct with ProductReadDTO
            var dtoProduct = _mapper.Map<List<ProductReadDTO>>(domainProduct.Value);

            return dtoProduct;

        }

        // GET: api/products/1
        /// <summary>
        /// Get a product by ID.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>A product object.</returns>
        /// <response code="200">Succesfully returns a product object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProject(int id)
        {
            // Instance of the product object.
            var domainProduct = await _product.GetProductAsync(id);

            // Map domainProduct to ProductReadDTO
            var dtoProduct = _mapper.Map<ProductReadDTO>(domainProduct.Value);

            if (dtoProduct == null)
            {
                return NotFound();
            }

            return dtoProduct;
        }
    }
}
