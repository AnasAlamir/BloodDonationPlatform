using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.Services.DTOs.User;
using BloodDonationPlatform.API.Services.Interfaces;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AuthResultDto> LoginAsync(string phoneNumber, string password)
    {
        var user = await _unitOfWork.UserRepository.GetByPhoneNumberAndPasswordAsync(phoneNumber, password);

        if (user == null)
            throw new Exception("Invalid credentials");

        return _mapper.Map<AuthResultDto>(user);
    }
}
