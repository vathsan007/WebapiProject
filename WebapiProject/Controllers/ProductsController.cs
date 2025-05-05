using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiProject.Authentication;
using WebapiProject.Data;
using WebapiProject.Models;
using WebapiProject.Repository;

namespace WebapiProject.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCorsPolicy")]
    [ApiController]
  

    public class ProductsController : ControllerBase
    {
        private readonly IProuductRepository _productRepository;

        public ProductsController(IProuductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productRepository.AddProduct(product);
                return Ok("Product added and stock updated successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(string id, [FromBody] Product product, long? quantityAdded = null)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            _productRepository.UpdateProduct(product, quantityAdded);
            return Ok("Product updated and stock updated successfully.");
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return Ok("Product deleted successfully.");
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "Product not found.")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("ProductByName/{Name}")]
        public IActionResult GetProductByName(string category)
        {
            try
            {
                var products = _productRepository.GetProductByName(category);
                return Ok(products);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "No products found in the given name.")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpGet("ProductByID/{id}")]
        
        public IActionResult GetProductById(string id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                return Ok(product);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "Product not found.")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[Authorize(Roles ="Admin")]
        [HttpGet("ProductBySupplierID/{sid}")]
        public IActionResult GetProductBySuppId(int sid)
        {
            try
            {
                var products = _productRepository.GetProductBySupplier(sid);
                return Ok(products);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "No products found for the given supplier.")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpGet("ProductByCategory/{category}")]
        public IActionResult GetProductByCategory(string category)
        {
            try
            {
                var products = _productRepository.GetProductByCategory(category);
                return Ok(products);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "No products found in the given category.")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[Authorize(Roles ="Admin,User")]
        [HttpGet]

        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }
    }
}
