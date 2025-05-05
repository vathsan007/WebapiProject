using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using WebapiProject.Models;

using WebapiProject.Repository;

namespace WebapiProject.Controllers

{

    [Route("api/[controller]")]

    [EnableCors("MyCorsPolicy")]
    
    [ApiController]
 

    public class StockController : ControllerBase

    {

        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)

        {

            _stockRepository = stockRepository;

        }


        //[Authorize(Roles = "Admin")]

        [HttpGet("AllStock")]

        public IActionResult GetAllStock()

        {

            try

            {

                var stocks = _stockRepository.GetAllStock();

                return Ok(stocks);

            }

            catch (System.Exception ex)

            {

                if (ex.Message == "No stock data found.")

                {

                    return NotFound(ex.Message);

                }

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        [HttpPost("AddStock")]

        public IActionResult AddStock(string productId, int quantity)

        {

            _stockRepository.AddStock(productId, quantity);

            return Ok("Stock added successfully.");

        }

        [HttpPost("ReduceStock")]

        public IActionResult ReduceStock(string productId, int quantity)

        {

            try

            {

                _stockRepository.ReduceStock(productId, quantity);

                return Ok("Stock reduced successfully.");

            }

            catch (System.Exception ex)

            {

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        // New endpoint to discard all stock

        [HttpPost("DiscardAllStock")]

        public IActionResult DiscardAllStock(string productId)

        {

            try

            {

                _stockRepository.DiscardAllStock(productId);

                return Ok($"All stock for product '{productId}' has been discarded.");

            }

            catch (System.Exception ex)

            {

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

       // [Authorize(Roles = "User,Admin")]

        [HttpGet("OutOfStock")]

        public IActionResult GetOutOfStockProducts()

        {

            try

            {

                var outOfStockProducts = _stockRepository.GetOutOfStockProducts();

                return Ok(outOfStockProducts);

            }

            catch (System.Exception ex)

            {

                if (ex.Message == "No out-of-stock products found.")

                {

                    return NotFound(ex.Message);

                }

                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

    }

}
