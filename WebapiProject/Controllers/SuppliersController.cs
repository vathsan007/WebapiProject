using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebapiProject.Data;
using WebapiProject.Models;
using WebapiProject.Repository;

namespace WebapiProject.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCorsPolicy")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _supplierRepository.AddSupplier(supplier);
            return Ok("Supplier added successfully.");
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] Supplier supplier)
        {
            if (supplier == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.SupplierId)
            {
                return BadRequest("Supplier ID mismatch.");
            }

            _supplierRepository.UpdateSupplier(supplier);
            return Ok("Supplier updated successfully.");
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            _supplierRepository.DeleteSupplier(id);
            return Ok("Supplier deleted successfully.");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            var supplier = _supplierRepository.GetSupplierById(id);
            if (supplier == null)
            {
                return NotFound("Supplier not found.");
            }
            return Ok(supplier);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            var suppliers = _supplierRepository.GetAllSuppliers();
            if (suppliers == null || !suppliers.Any())
            {
                return NotFound("No suppliers found.");
            }
            return Ok(suppliers);
        }
    }
}
