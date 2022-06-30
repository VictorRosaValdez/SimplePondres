using Microsoft.AspNetCore.Mvc;
using SimplePondres.Models;

namespace SimplePondres.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Abstract method to get all orders.
        /// </summary>
        /// <returns>A list of orders.</returns>
        Task<ActionResult<IEnumerable<Order>>> GetOrdersAsync();

        /// <summary>
        /// Abstract method to get a order by Id.
        /// </summary>
        /// <param name="id">The id of the order.</param>
        /// <returns>The order object.</returns>
        Task<ActionResult<Order>> GetOrderAsync(int id);

        /// <summary>
        /// Abstract method to add a new order.
        /// </summary>
        /// <param name="order">Order type</param>
        /// <returns>The new order object.</returns>
        Task<ActionResult<Order>> PostOrderAsync(Order order);
    }
}
