using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;
using BloodDonationPlatform.API.Services.Interfaces;
using System.Drawing;
namespace BloodDonationPlatform.API.Services.Services
{
    public class DonationRequestService : IDonationRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DonationRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetHospitalDonationRequestDTO> CreateDonationRequestAsync(CreateHospitalDonationRequestDTO dto)
        {
            var hospital = await _unitOfWork.HospitalRepository.GetByIdAsync(dto.HospitalId);
            if (hospital == null)
                throw new HospitalNotFoundExceptions(dto.HospitalId);
            if (dto.NumOfLiter <= 0)
                throw new ArgumentException("Cannot create a request with zero quantity");
            var donationRequest = _mapper.Map<DonationRequest>(dto);

            var allDonors = await _unitOfWork.DonorRepository.GetAllAsync();
            var eligibleDonors = allDonors
                                    .Where(donor =>
                                        donor.BloodTypeId == dto.BloodTypeId &&
                                        donor.AreaId == hospital.AreaId &&
                                        (
                                            donor.DonorDonationRequests == null ||
                                            !donor.DonorDonationRequests.Any() || // never donated → eligible
                                            donor.DonorDonationRequests.Max(dr => dr.LastDateOfDonation) <= DateTime.UtcNow.AddMonths(-3) // last donation ≥ 3 months ago
                                        )
                                    )
                                    .ToList();

            var donorDonationRequests = eligibleDonors
                .Select(donor => new DonorDonationRequest
                {
                    DonorId = donor.Id,
                    DonationRequestId = donationRequest.Id,
                    DonorApprovalStatus = null,
                    DonationRequest = donationRequest
                })
                .ToList();
            await _unitOfWork.DonationRequestRepository.InsertAsync(donationRequest);
            await _unitOfWork.DonorDonationRequestRepository.InsertRangeAsync(donorDonationRequests);
            await _unitOfWork.SaveAsync();

            var createdDonationRequest = await _unitOfWork.DonationRequestRepository.GetByIdAsync(donationRequest.Id);
            if (createdDonationRequest == null)
                throw new InvalidOperationException();
            return _mapper.Map<GetHospitalDonationRequestDTO>(createdDonationRequest);
        }
        public async Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllActiveRequestsByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest != StatesRequest.Completed && r.HospitalId == hospitalId);
            return _mapper.Map<IEnumerable<GetHospitalDonationRequestDTO>>(activeRequests);
        }
        public async Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllCompletedRequestsByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest == StatesRequest.Completed && r.HospitalId == hospitalId);
            return _mapper.Map<IEnumerable<GetHospitalDonationRequestDTO>>(activeRequests);
        }
        public async Task<int> GetOpenRequestsCountByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest == StatesRequest.Open && r.HospitalId == hospitalId);
            return activeRequests.Count();
        }
        public async Task<int> GetCompletedRequestsCountByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest == StatesRequest.Completed && r.HospitalId == hospitalId);
            return activeRequests.Count();
        }
        public async Task<IEnumerable<GetDonorDonationRequestDTO>> GetAllRequestsByDonorIdAsync(int donorId)
        {
            var requests = await _unitOfWork.DonorDonationRequestRepository.GetAllByDonorIdAsync(donorId);
            var activeRequests = requests.Where(r => r.DonationRequest.StatesRequest != StatesRequest.Completed);
            var lastDateOfDonation = activeRequests.Max(r => r.LastDateOfDonation);
            var requestsToReturn = activeRequests.Where(r => r.DonorApprovalStatus == true ||
                                                                (r.DonorApprovalStatus == null &&
                                                                 lastDateOfDonation <= DateTime.UtcNow.AddMonths(-3)));
            return _mapper.Map<List<GetDonorDonationRequestDTO>>(requestsToReturn);
        }
        public async Task<bool> ApproveDonationRequestByDonorDonationRequestIdAsync(int donorDonationRequestId)
        {
            var donorDonationRequest = await _unitOfWork.DonorDonationRequestRepository
                                                        .GetDonorDonationRequestByIdAsync(donorDonationRequestId);
            if (donorDonationRequest == null)
                throw new NotFoundExcptiondonorDonationRequest(donorDonationRequestId);
            var request = donorDonationRequest.DonationRequest;
            if (request.StatesRequest == StatesRequest.Completed || request.NumOfLiter <= 0)
                return false;
            if (donorDonationRequest.DonorApprovalStatus == true)
                return false;
            donorDonationRequest.DonorApprovalStatus = true;
            donorDonationRequest.LastDateOfDonation = DateTime.UtcNow;
            donorDonationRequest.Donor.TotalPoints += 100;
            request.NumOfLiter -= 1;
            if (request.NumOfLiter <= 0)
                request.StatesRequest = StatesRequest.Completed;
            _unitOfWork.DonorDonationRequestRepository.Update(donorDonationRequest);
            _unitOfWork.DonationRequestRepository.Update(request);
            await _unitOfWork.SaveAsync();
            return true;
        }
        public async Task<bool> RejectDonationRequestByDonorDonationRequestIdAsync(int donorDonationRequestId)
        {
            var donorDonationRequest = await _unitOfWork.DonorDonationRequestRepository
                                            .GetDonorDonationRequestByIdAsync(donorDonationRequestId);
            if (donorDonationRequest == null)
                throw new NotFoundExcptiondonorDonationRequest(donorDonationRequestId);
            await _unitOfWork.DonorDonationRequestRepository.DeleteAsync(donorDonationRequestId);
            await _unitOfWork.SaveAsync();
            return true;
        }
        //public async Task<GetHospitalDonationRequestDTO> CreateAsync(CreateHospitalDonationRequestDTO dto)
        //{
        //    var donationRequest = _mapper.Map<DonationRequest>(dto);
        //    await _unitOfWork.DonationRequestRepository.InsertAsync(donationRequest);
        //    await _unitOfWork.SaveAsync();
        //    var createdDonationRequest = await _unitOfWork.DonationRequestRepository.GetByIdAsync(donationRequest.Id);
        //    if (createdDonationRequest == null)
        //        throw new InvalidOperationException();

        //    var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();

        //    var pendingCount = requests.Where(r => r.StatesRequest != StatesRequest.Completed &&
        //                                           r.HospitalId == donationRequest.HospitalId).ToList().Count;
        //    var completedCount = requests.Where(r => r.StatesRequest == StatesRequest.Pending &&
        //                                           r.HospitalId == donationRequest.HospitalId).ToList().Count;
        //    return new GetHospitalDonationRequestsDTO
        //    {
        //        GetHospitalDonationRequestDTOs = new List<GetHospitalDonationRequestDTO>
        //        {
        //            _mapper.Map<GetHospitalDonationRequestDTO>(createdDonationRequest)
        //        },
        //        PendingRequestsCount = pendingCount,
        //        CompletedRequestsCount = completedCount
        //    };
        //}

    }
}
//// موافقة المتبرع على الطلب
//public async Task<bool> ApproveDonationRequestByDonorDonationRequestIdAsync(DonorActionDto dto)
//{
//    var donorRequest = await _context.DonorDonationRequests
//        .Include(dr => dr.DonationRequest)
//        .FirstOrDefaultAsync(dr => dr.DonorId == dto.DonorId && dr.DonationRequestId == dto.RequestId);

//    if (donorRequest == null)
//        return false;

//    var request = donorRequest.DonationRequest;

//    if (request.StatesRequest == StatesRequest.Completed || request.NumOfLiter <= 0)
//        return false;

//    if (donorRequest.DonorApprovalStatus == true)
//        return false;

//    donorRequest.DonorApprovalStatus = true;
//    donorRequest.LastDateOfDonation = DateTime.UtcNow;

//    request.NumOfLiter -= 1;

//    if (request.NumOfLiter <= 0)
//        request.StatesRequest = StatesRequest.Completed;

//    await _context.SaveChangesAsync();
//    return true;
//}

//// رفض المتبرع للطلب
//public async Task<bool> RejectDonationRequestByDonorDonationRequestIdAsync(DonorActionDto dto)
//{
//    var donorRequest = await _context.DonorDonationRequests
//        .FirstOrDefaultAsync(dr => dr.DonorId == dto.DonorId && dr.DonationRequestId == dto.RequestId);

//    if (donorRequest != null)
//    {
//        _context.DonorDonationRequests.Remove(donorRequest);
//        await _context.SaveChangesAsync();
//    }

//    return true;
//}

//// عرض الطلبات في Dashboard المستشفى
//public async Task<List<RequestDashboardDto>> GetDashboardRequestsAsync()
//{
//    var requests = await _context.DonorDonationRequests
//        .Include(r => r.BloodType)
//        .ToListAsync();

//    return _mapper.Map<List<RequestDashboardDto>>(requests);
//}