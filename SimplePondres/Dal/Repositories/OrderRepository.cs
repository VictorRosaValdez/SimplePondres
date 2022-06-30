using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePondres.Interfaces;
using SimplePondres.Models;

namespace SimplePondres.Dal.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly SimplePondresDbContext _context;

        /// <summary>
        /// Constructor for the OrderRepository.
        /// </summary>
        /// <param name="context"></param>
        public OrderRepository(SimplePondresDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a order by Id
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns>A order object</returns>
        public async Task<ActionResult<Order>> GetOrderAsync(int id)
        {
            var order = await _context.Order.FindAsync(id);

            return order;
        }

        /// <summary>
        ///  Get all orders
        /// </summary>
        /// <returns>A list of orders</returns>
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAsync()
        {
            var order = await _context.Order.ToListAsync();

            return order;

        }

        /// <summary>
        /// Add a new product object
        /// </summary>
        /// <param name="order">Order object</param>
        /// <returns>The new order object</returns>
        public async Task<ActionResult<Order>> PostOrderAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
