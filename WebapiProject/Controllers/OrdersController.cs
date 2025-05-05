using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiProject.Data;
using WebapiProject.Models;
using WebapiProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;


namespace WebapiProject.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCorsPolicy")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        //[Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            try
            {
                // Get the user ID from the logged-in user
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not logged in.");
                }

                // Set the user ID, order status, and order date
                order.UserId = int.Parse(userId);
                order.Status = "Placed";
                order.OrderDate = DateTime.Now;

                _orderRepository.PlaceOrder(order);
                return Ok("Order placed and stock updated successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateOrderStatus(int id, [FromBody] string status)
        {
            try
            {
                _orderRepository.UpdateOrderStatus(id, status);
                return Ok("Order status updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Order not found.");
            }
        }
        //[Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }
            return Ok(order);
        }
        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found.");
            }
            return Ok(orders);
        }
        [HttpDelete("{id}")]
        public IActionResult CancelOrder(int id)
        {
            try
            {
                _orderRepository.CancelOrder(id);
                return Ok("Order cancelled successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Order not found.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("details")]

        public IActionResult GetOrderedProductDetails()

        {

            try

            {

                var orderedProductDetails = _orderRepository.GetOrderedProductDetails();

                if (orderedProductDetails == null || !orderedProductDetails.Any())

                {

                    return NotFound("No ordered product details found.");

                }

                return Ok(orderedProductDetails);

            }

            catch (System.Exception ex)

            {

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [HttpGet("history")]

        public IActionResult GetOrderHistory()

        {

            try

            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))

                {

                    return Unauthorized("User not logged in.");

                }

                var orders = _orderRepository.GetOrderHistoryByUserId(int.Parse(userId));

                if (orders == null || !orders.Any())

                {

                    return NotFound("No orders found.");

                }

                return Ok(orders);

            }

            catch (System.Exception ex)

            {

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

    }
}

