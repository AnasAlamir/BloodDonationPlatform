using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.DTOs.Inventory;
using BloodDonationPlatform.API.Services.Interfaces;
using BloodDonationPlatform.API.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet("{hospitalId}")]
        public async Task<IActionResult> GetAllInventoriesByHospitalIdAsync(int hospitalId)
        {
            var inventories = await _inventoryService.GetAllInventoriesByHospitalIdAsync(hospitalId);
            return Ok(inventories);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryById(int id, [FromBody] UpdateBloodInventoryDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _inventoryService.UpdateInventoryByIdAsync(id, dto);
            if (updated == null)
                throw new HospitalNotFoundExceptions(id);

            return Ok(updated);
        }
        //[HttpPut("update-status")]
        //public async Task<IActionResult> UpdateStatus()
        //{
        //    await _inventoryService.UpdateInventoryStatusAsync();
        //    return NoContent();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddInventory([FromBody] UpdateBloodInventoryDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _inventoryService.AddInventoryAsync(dto);
        //    return Ok(result);
        //}

    }
}
