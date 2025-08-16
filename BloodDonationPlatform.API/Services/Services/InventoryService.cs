using AutoMapper;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Inventory;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.Services.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly BloodDonationDbContext _context;
        private readonly IMapper _mapper;

        public InventoryService(BloodDonationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBloodInventoryDTO>> GetAllAsync()
        {
            var inventories = _context.Inventories.ToList();
            var inventoryDtos = _mapper.Map<IEnumerable<GetBloodInventoryDTO>>(inventories);
            var Result = inventoryDtos.Select(i => new GetBloodInventoryDTO
            {
                Id = i.Id,
                BloodType = i.BloodType,
                CurrentQuantity = i.CurrentQuantity,
                ExpirationDate = i.ExpirationDate,
                Status = i.Status
            });
            return Result;
        }

        private StatusInventory GetStatus(int quantity, DateTime expiration)
        {
            if (expiration < DateTime.UtcNow)
                return StatusInventory.Expired;
            if (quantity <= 0)
                return StatusInventory.NotAvailable;
            if (quantity < 10)
                return StatusInventory.LowStok;
            return StatusInventory.Available;
        }

        public async Task<GetBloodInventoryDTO> AddInventoryAsync(CreateBloodInventoryDTO dto)
        {
            {
                var existingInventory = await _context.Inventories
                    .FirstOrDefaultAsync(i => i.BloodTypeId == dto.BloodTypeId && i.HospitalId == dto.HospitalId);

                var expiration = DateTime.UtcNow.AddDays(35);

                if (existingInventory == null)
                {
                    var newInventory = _mapper.Map<Inventory>(dto);
                    newInventory.ExpirationDate = expiration;
                    newInventory.MinimunQuantity = 10;
                    newInventory.StatusInventory = GetStatus(dto.Quantity, expiration);

                    _context.Inventories.Add(newInventory);
                    await _context.SaveChangesAsync();

                    return _mapper.Map<GetBloodInventoryDTO>(newInventory);
                }
                else
                {
                    existingInventory.CurrentQuantity = dto.Quantity;
                    existingInventory.ExpirationDate = expiration;
                    existingInventory.StatusInventory = GetStatus(dto.Quantity, expiration);

                    await _context.SaveChangesAsync();
                    var Result = _mapper.Map<GetBloodInventoryDTO>(existingInventory);
                    return Result;
                }
            }
        }

        public async Task UpdateInventoryStatusAsync()
        {
            var inventories = await _context.Inventories.ToListAsync();

            foreach (var inventory in inventories)
            {
                inventory.StatusInventory = GetStatus(inventory.CurrentQuantity, inventory.ExpirationDate);
            }

            await _context.SaveChangesAsync();
        }
    }
}
