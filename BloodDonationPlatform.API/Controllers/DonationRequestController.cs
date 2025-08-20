using Microsoft.AspNetCore.Mvc;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.Interfaces;
using AutoMapper;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;
using BloodDonationPlatform.API.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var requests = await _donationRequestService.GetAllActiveRequestsByHospitalIdAsync(hospitalId);
            return Ok(requests);
        }
        [HttpGet("hospital/completed/{hospitalId}")]
        public async Task<IActionResult> GetAllCompletedByHospitalId(int hospitalId)
        {
            var requests = await _donationRequestService.GetAllCompletedRequestsByHospitalIdAsync(hospitalId);
            return Ok(requests);
        }
        [HttpGet("hospital/open-requests/{hospitalId}")]
        public async Task<IActionResult> GetOpenRequestsCountByHospitalId(int hospitalId)
        {
            var count = await _donationRequestService.GetOpenRequestsCountByHospitalIdAsync(hospitalId);
            return Ok(count);
        }
        [HttpGet("hospital/completed-requests/{hospitalId}")]
        public async Task<IActionResult> GetCompletedRequestsCountByHospitalId(int hospitalId)
        {
            var count = await _donationRequestService.GetCompletedRequestsCountByHospitalIdAsync(hospitalId);
            return Ok(count);
        }

        // POST: api/DonationRequest
        [HttpPost]
        public async Task<IActionResult> CreateDonationRequest([FromBody] CreateHospitalDonationRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _donationRequestService.CreateDonationRequestAsync(dto);
            return Ok(created);
            //return CreatedAtAction(nameof(GetById), new { id = created.AreaId }, created);
        }


        [HttpPut("donor/{donorDonationRequestId}/approve")]
        public async Task<IActionResult> ApproveDonationRequestByDonorDonationRequestId(int donorDonationRequestId)
        {
            var result = await _donationRequestService.ApproveDonationRequestByDonorDonationRequestIdAsync(donorDonationRequestId);
            if (!result)
                return BadRequest(new { Message = "Unable to approve the request. It may be already completed or invalid." });
            return Ok(result);
        }

        [HttpPut("donor/{donorDonationRequestId}/reject")]
        public async Task<IActionResult> RejectDonationRequestByDonorDonationRequestId(int donorDonationRequestId)
        {
            var result = await _donationRequestService.RejectDonationRequestByDonorDonationRequestIdAsync(donorDonationRequestId);
            return Ok(result);
        }
        [HttpGet("donor/{donorId}")]
        public async Task<IActionResult> GetAllRequestsByDonorId(int donorId)
        {
            var requests = await _donationRequestService.GetAllRequestsByDonorIdAsync(donorId);
            return Ok(requests);
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
//using Microsoft.AspNetCore.Mvc;
//using BloodDonationPlatform.API.Services.Interfaces;
//using BloodDonationPlatform.API.Services.DTOs;
//using BloodDonationPlatform.API.Services.DTOs.DonationRequest;

//namespace BloodDonationPlatform.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class DonationRequestController : ControllerBase
//    {
//        //private readonly IDonationRequestService _donationRequestService;

//        public DonationRequestController(IDonationRequestService donationRequestService)
//        {
//            _donationRequestService = donationRequestService;
//        }

//        // Create a new donation request
//        [HttpPost]
//        public async Task<IActionResult> CreateRequest([FromBody] CreateHospitalDonationRequestDTO dto)
//        {
//            try
//            {
//                var requestId = await _donationRequestService.CreateDonationRequestAsync(dto);
//                return Ok(new { RequestId = requestId });
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(new { Message = ex.Message });
//            }
//        }

//        // Donor approves a request
//        [HttpPost("approve")]
//        public async Task<IActionResult> ApproveRequest([FromBody] DonorActionDto dto)
//        {
//            var success = await _donationRequestService.ApproveRequestAsync(dto);
//            if (!success)
//                return BadRequest(new { Message = "Unable to approve the request. It may be already completed or invalid." });

//            return Ok(new { Message = "Request approved successfully." });
//        }

//        // Donor rejects a request
//        [HttpPost("reject")]
//        public async Task<IActionResult> RejectRequest([FromBody] DonorActionDto dto)
//        {
//            var success = await _donationRequestService.RejectRequestAsync(dto);
//            return Ok(new { Message = "Request rejected successfully." });
//        }

//        // Hospital dashboard view
//        [HttpGet("dashboard")]
//        public async Task<IActionResult> GetDashboardRequests()
//        {
//            var requests = await _donationRequestService.GetDashboardRequestsAsync();
//            return Ok(requests);
//        }


//    }
//}
