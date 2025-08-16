using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.Interfaces;

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
        public async Task<GetHospitalDonationRequestDTO> CreateAsync(CreateDonationRequestDTO dto)
        {
            var donationRequest = _mapper.Map<DonationRequest>(dto);
            await _unitOfWork.DonationRequestRepository.InsertAsync(donationRequest);
            await _unitOfWork.SaveAsync();
            var createdDonationRequest = await _unitOfWork.DonationRequestRepository.GetByIdAsync(donationRequest.Id);
            if (createdDonationRequest == null)
                throw new InvalidOperationException();
            return _mapper.Map<GetHospitalDonationRequestDTO>(createdDonationRequest);
        }
        //public async Task<GetHospitalDonationRequestDTO> CreateAsync(CreateDonationRequestDTO dto)
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
        public async Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllActiveByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r =>   r.StatesRequest != StatesRequest.Completed && r.HospitalId == hospitalId);
            return _mapper.Map<IEnumerable<GetHospitalDonationRequestDTO>>(activeRequests);
        }

        public async Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllCompletedByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest == StatesRequest.Completed && r.HospitalId == hospitalId);
            return _mapper.Map<IEnumerable<GetHospitalDonationRequestDTO>>(activeRequests);
        }

        public async Task<int> GetOpenRequestsCountByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest != StatesRequest.Completed && r.HospitalId == hospitalId);
            return activeRequests.Count();
        }

        public async Task<int> GetPendingRequestsCountByHospitalIdAsync(int hospitalId)
        {
            var requests = await _unitOfWork.DonationRequestRepository.GetAllAsync();
            var activeRequests = requests.Where(r => r.StatesRequest == StatesRequest.Pending && r.HospitalId == hospitalId);
            return activeRequests.Count();
        }
    }
}
