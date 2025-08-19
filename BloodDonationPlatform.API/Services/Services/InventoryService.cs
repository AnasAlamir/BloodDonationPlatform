using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.UnitOfWork;
using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs.Inventory;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.Services.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InventoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetBloodInventoryDTO?> UpdateInventoryByIdAsync(int inventoryId, UpdateBloodInventoryDTO dto)
        {
            var inventory = await _unitOfWork.InventoryRepository
                    .GetByIdAsync(inventoryId);
            if (inventory == null) throw new InvalidOperationException();
            _mapper.Map(dto, inventory);
            _unitOfWork.InventoryRepository.Update(inventory);
            await _unitOfWork.SaveAsync();
            var updated = await _unitOfWork.InventoryRepository.GetByIdAsync(inventoryId);
            return _mapper.Map<GetBloodInventoryDTO>(updated);
        }
        public async Task<IEnumerable<GetBloodInventoryDTO>> GetAllInventoriesByHospitalIdAsync(int hospitalId)
        {
            var inventories = await _unitOfWork.InventoryRepository.GetAllByHospitalIdAsync(hospitalId);
            return _mapper.Map<IEnumerable<GetBloodInventoryDTO>>(inventories);
        }
        //private StatusInventory GetStatus(int quantity, int minimunQuantity, DateTime expirationDate)
        //{
        //    if (expirationDate < DateTime.UtcNow)
        //        return StatusInventory.Expired;
        //    if (quantity <= 0)
        //        return StatusInventory.NotAvailable;
        //    if (quantity < minimunQuantity)
        //        return StatusInventory.LowStock;
        //    return StatusInventory.Available;
        //}
        
        //public async Task<IEnumerable<GetBloodInventoryDTO>> GetAllAreasAsync()
        //{
        //    var inventories = _context.Inventories.ToList();
        //    var inventoryDtos = _mapper.Map<IEnumerable<GetBloodInventoryDTO>>(inventories);
        //    var Result = inventoryDtos.Select(i => new GetBloodInventoryDTO
        //    {
        //        Id = i.Id,
        //        BloodTypeName = i.BloodTypeName,
        //        CurrentQuantity = i.CurrentQuantity,
        //        ExpirationDate = i.ExpirationDate,
        //        Status = i.Status
        //    });
        //    return Result;
        //}

        /// <summary>
        /// ghgj
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>

        

        //public async Task<GetBloodInventoryDTO> AddInventoryAsync(CreateBloodInventoryDTO dto)
        //{
        //    {
        //        var existingInventory = await _context.Inventories
        //            .FirstOrDefaultAsync(i => i.BloodTypeId == dto.BloodTypeId && i.HospitalId == dto.HospitalId);

        //        var expiration = DateTime.UtcNow.AddDays(35);

        //        if (existingInventory == null)
        //        {
        //            var newInventory = _mapper.Map<Inventory>(dto);
        //            newInventory.ExpirationDate = expiration;
        //            newInventory.MinimunQuantity = 10;
        //            newInventory.StatusInventory = GetStatus(dto.Quantity, expiration);

        //            _context.Inventories.Add(newInventory);
        //            await _context.SaveChangesAsync();

        //            return _mapper.Map<GetBloodInventoryDTO>(newInventory);
        //        }
        //        else
        //        {
        //            existingInventory.CurrentQuantity = dto.Quantity;
        //            existingInventory.ExpirationDate = expiration;
        //            existingInventory.StatusInventory = GetStatus(dto.Quantity, expiration);

        //            await _context.SaveChangesAsync();
        //            var Result = _mapper.Map<GetBloodInventoryDTO>(existingInventory);
        //            return Result;
        //        }
        //    }
        //}

        //public async Task UpdateInventoryStatusAsync()
        //{
        //    var inventories = await _context.Inventories.ToListAsync();

        //    foreach (var inventory in inventories)
        //    {
        //        inventory.StatusInventory = GetStatus(inventory.CurrentQuantity, inventory.ExpirationDate);
        //    }

        //    await _context.SaveChangesAsync();
        //}

        

        
    }
}
