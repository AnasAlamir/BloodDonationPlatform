using BloodDonationPlatform.API.Services.DTOs.Inventory;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BloodInventoryController : ControllerBase
        {
            private readonly IInventoryService _inventoryService;

            public BloodInventoryController(IInventoryService inventoryService)
            {
                _inventoryService = inventoryService;
            }

            [HttpPost]
            public async Task<IActionResult> AddInventory([FromBody] CreateBloodInventoryDTO dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _inventoryService.AddInventoryAsync(dto);
                return Ok(result);
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var inventories = await _inventoryService.GetAllAsync();
                return Ok(inventories);
            }

            [HttpPut("update-status")]
            public async Task<IActionResult> UpdateStatus()
            {
                await _inventoryService.UpdateInventoryStatusAsync();
                return NoContent();
            }
        }
    }
}

