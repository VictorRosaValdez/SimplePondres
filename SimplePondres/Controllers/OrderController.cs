using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimplePondres.DTOs.OrderDTOs;
using SimplePondres.Interfaces;
using SimplePondres.Models;
using System.Net.Mime;

namespace SimplePondres.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrderController : ControllerBase
    {
        // Fields 
        private readonly IOrderRepository _order;

        private readonly IMapper _mapper;
        public OrderController(IOrderRepository order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;

        }

        // GET: api/orders
        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <response code="200">Succesfully returns a order object.</response>
        /// <returns>A list of order objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetOrders()
        {
            // Instance of the domainOrder objects.
            var domainOrder = await _order.GetOrdersAsync();

            // Map domainOrder with OrderReadDTO
            var dtoOrder = _mapper.Map<List<OrderReadDTO>>(domainOrder.Value);

            return dtoOrder;

        }

        // GET: api/orders/1
        /// <summary>
        /// Get a order by ID.
        /// </summary>
        /// <param name="id">Id of the order.</param>
        /// <returns>A order object.</returns>
        /// <response code="200">Succesfully returns a order object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDTO>> GetOrder(int id)
        {
            // Instance of the order object.
            var domainOrder = await _order.GetOrderAsync(id);

            // Map domainOrder to OrderReadDTO
            var dtoOrder = _mapper.Map<OrderReadDTO>(domainOrder.Value);

            if (dtoOrder == null)
            {
                return NotFound();
            }

            return dtoOrder;
        }

        // POST: api/orders
        /// <summary>
        /// Creates a new order object.
        /// </summary>
        /// <param name="order">A order object.</param>
        /// <returns>The new order object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<OrderCreateDTO>> PostOrder(OrderCreateDTO orderDto)
        {

            // Map OrderCreateDTO to domain object
            var domainOrder = _mapper.Map<Order>(orderDto);

            // New order object
            await _order.PostOrderAsync(domainOrder);

            // Get order id for new order object.
            int orderId = _order.PostOrderAsync(domainOrder).Id;

            // Returning the new order.
            return CreatedAtAction("GetOrder", new { id = orderId }, orderDto);
        }

    }
}
