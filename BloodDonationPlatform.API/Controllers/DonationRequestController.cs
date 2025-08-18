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