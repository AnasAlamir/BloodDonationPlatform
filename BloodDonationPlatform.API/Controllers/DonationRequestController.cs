using Microsoft.AspNetCore.Mvc;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.Interfaces;
using AutoMapper;

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
        [HttpGet("hospital/active/{hospitalId}")]
        public async Task<IActionResult> GetAllActiveByHospitalId(int hospitalId)
        {
            var requests = await _donationRequestService.GetAllActiveByHospitalIdAsync(hospitalId);
            return Ok(requests);
        }
        [HttpGet("hospital/completed/{hospitalId}")]
        public async Task<IActionResult> GetAllCompletedByHospitalId(int hospitalId)
        {
            var requests = await _donationRequestService.GetAllCompletedByHospitalIdAsync(hospitalId);
            return Ok(requests);
        }
        [HttpGet("hospital/open-requests/{hospitalId}")]
        public async Task<IActionResult> GetOpenRequestsCountByHospitalId(int hospitalId)
        {
            var count = await _donationRequestService.GetOpenRequestsCountByHospitalIdAsync(hospitalId);
            return Ok(count);
        }
        [HttpGet("hospital/pending-requests/{hospitalId}")]
        public async Task<IActionResult> GetPendingRequestsCountByHospitalId(int hospitalId)
        {
            var count = await _donationRequestService.GetPendingRequestsCountByHospitalIdAsync(hospitalId);
            return Ok(count);
        }

        // POST: api/DonationRequest
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonationRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _donationRequestService.CreateAsync(dto);
            return Ok(created);
            //return CreatedAtAction(nameof(GetById), new { id = created.AreaId }, created);
        }

        //// PUT: api/DonationRequest/status
        //[HttpPut("status")]
        //public async Task<IActionResult> UpdateStatus([FromBody] UpdateDonationRequestStatusDTO dto)
        //{
        //    var updated = await _donationRequestService.UpdateStatusAsync(dto);
        //    if (!updated) return NotFound();
        //    return NoContent();
        //}
        //// GET: api/DonationRequest/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var request = await _donationRequestService.GetBloodTypeByIdAsync(id);
        //    if (request == null) return NotFound();
        //    return Ok(request);
        //}
    }
}
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
