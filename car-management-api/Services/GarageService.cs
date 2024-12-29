namespace car_management_api.Services
{
    using car_management_api.Dtos;
    using car_management_api.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GarageService : IGarageService
    {
        private readonly DatabasebContext _context;

        public GarageService(DatabasebContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseGarageDto>> GetAllGarages(string? city)
        {
            var garagesQuery = _context.Garages.AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                garagesQuery = garagesQuery.Where(g => g.City.Contains(city));
            }

            var garageDtos = await garagesQuery.Select(g => new ResponseGarageDto
            {
                Id = g.Id,
                Name = g.Name,
                City = g.City,
                Location = g.Location,
                Capacity = g.Capacity,
            }).ToListAsync();

            return garageDtos;
        }

        public async Task<ResponseGarageDto> GetGarageById(int id)
        {
            var garageDto = await _context.Garages
                .Where(g => g.Id == id)
                .Select(g => new ResponseGarageDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    City = g.City,
                    Location = g.Location,
                    Capacity = g.Capacity,
                })
                .FirstOrDefaultAsync();

            return garageDto;
        }

        public async Task<ResponseGarageDto> CreateGarage(CreateGarageDto garageDto)
        {
            var garage = new Garage
            {
                Name = garageDto.Name,
                City = garageDto.City,
                Location = garageDto.Location,
                Capacity = garageDto.Capacity
            };

            await _context.Garages.AddAsync(garage);
            await _context.SaveChangesAsync();

            return await GetGarageById(garage.Id);
        }

        public async Task<ResponseGarageDto> UpdateGarage(int id, UpdateGarageDto garageDto)
        {
            var garage = await _context.Garages.FirstOrDefaultAsync(g => g.Id == id);

            if (garage == null)
            {
                return null;
            }

            garage.Name = garageDto.Name ?? garage.Name;
            garage.City = garageDto.City ?? garage.City;
            garage.Location = garageDto.Location ?? garage.Location;
            garage.Capacity = garageDto.Capacity != garage.Capacity ? garageDto.Capacity : garage.Capacity;

            _context.Garages.Update(garage);
            await _context.SaveChangesAsync();

            return await GetGarageById(garage.Id);
        }

        public async Task<bool> DeleteGarage(int id)
        {
            var garage = await _context.Garages.FirstOrDefaultAsync(g => g.Id == id);

            if (garage == null)
            {
                return false;
            }

            _context.Garages.Remove(garage);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
