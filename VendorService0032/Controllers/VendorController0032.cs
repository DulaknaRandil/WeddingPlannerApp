using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorService0032.Models;
using VendorService0032.Service.IService;

namespace VendorService0032.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController0032 : ControllerBase
    {
        private readonly IVendor0032Service _vendorService;

        public VendorController0032(IVendor0032Service vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost("AddVendor")]
        public IActionResult AddVendor([FromBody] Vendor0032 vendor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newVendor = _vendorService.AddVendor(vendor);
            return CreatedAtAction(nameof(GetVendorById), new { id = newVendor.Id }, newVendor);
        }

        [HttpGet("GetVendorById/{id}")]
        public IActionResult GetVendorById(string id)
        {
            var vendor = _vendorService.GetVendorById(id);
            if (vendor == null)
                return NotFound();

            return Ok(vendor);
        }

        [HttpGet("GetAllVendors")]
        public IActionResult GetAllVendors()
        {
            return Ok(_vendorService.GetAllVendors());
        }

        [HttpPut("UpdateVendor/{id}")]
        public IActionResult UpdateVendor(string id, [FromBody] Vendor0032 updatedVendor)
        {
            var vendor = _vendorService.UpdateVendor(id, updatedVendor);
            if (vendor == null)
                return NotFound();

            return Ok(vendor);
        }

        [HttpDelete("DeleteVendor/{id}")]
        public IActionResult DeleteVendor(string id)
        {
            var result = _vendorService.DeleteVendor(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
