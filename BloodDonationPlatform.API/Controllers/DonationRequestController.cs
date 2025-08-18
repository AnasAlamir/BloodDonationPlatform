using Microsoft.AspNetCore.Mvc;
using BloodDonationPlatform.API.Services.Interfaces;
using BloodDonationPlatform.API.Services.DTOs;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;

namespace BloodDonationPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationRequestController : ControllerBase
    {
        private readonly IDonationRequestService _donationRequestService;

        public DonationRequestController(IDonationRequestService donationRequestService)
        {
            _donationRequestService = donationRequestService;
        }

        // Create a new donation request
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateDonationRequestDTO dto)
        {
            try
            {
                var requestId = await _donationRequestService.CreateDonationRequestAsync(dto);
                return Ok(new { RequestId = requestId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Donor approves a request
        [HttpPost("approve")]
        public async Task<IActionResult> ApproveRequest([FromBody] DonorActionDto dto)
        {
            var success = await _donationRequestService.ApproveRequestAsync(dto);
            if (!success)
                return BadRequest(new { Message = "Unable to approve the request. It may be already completed or invalid." });

            return Ok(new { Message = "Request approved successfully." });
        }

        // Donor rejects a request
        [HttpPost("reject")]
        public async Task<IActionResult> RejectRequest([FromBody] DonorActionDto dto)
        {
            var success = await _donationRequestService.RejectRequestAsync(dto);
            return Ok(new { Message = "Request rejected successfully." });
        }

        // Hospital dashboard view
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardRequests()
        {
            var requests = await _donationRequestService.GetDashboardRequestsAsync();
            return Ok(requests);
        }

      
    }
}
