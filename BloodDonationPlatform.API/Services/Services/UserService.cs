//using AutoMapper;
//using BloodDonationPlatform.API.DataAccess.DataContext;
//using BloodDonationPlatform.API.Services.DTOs.User;
//using BloodDonationPlatform.API.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace BloodDonationPlatform.API.Services.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly BloodDonationDbContext _context;
//        private readonly IMapper _mapper;

//        public UserService(BloodDonationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<AuthResultDto> LoginAsync(string identifier, string password)
//        {
//            var user = await _context.Users
//          .Include(u => u.Hospital)
//          .Include(u => u.Donor)
//          .FirstOrDefaultAsync(u => u.Identifier == identifier && u.Password == password);

//            if (user == null)
//                throw new Exception("Invalid credentials");

//            return _mapper.Map<AuthResultDto>(user);

//        }

//    }
//}
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

    public async Task<AuthResultDto> LoginAsync(string identifier, string password)
    {
        var user = await _unitOfWork.UserRepository.GetByIdentifierAsync(identifier, password);

        if (user == null)
            throw new Exception("Invalid credentials");

        return _mapper.Map<AuthResultDto>(user);
    }
}
