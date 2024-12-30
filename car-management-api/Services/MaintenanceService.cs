namespace car_management_api.Services
{
    using car_management_api.Dtos;
    using car_management_api.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public class MaintenanceService : IMaintenanceService
    {
        private readonly DatabasebContext _context;

        public MaintenanceService(DatabasebContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseMaintenanceDto>> GetAllMaintenances(int? carId, int? garageId, string? startDate, string? endDate)
        {
            var maintenanceQuery = _context.Maintenances.AsQueryable();

            if (carId > 0)
            {
                maintenanceQuery = maintenanceQuery.Where(m => m.CarId == carId);
            }

            if (garageId > 0)
            {
                maintenanceQuery = maintenanceQuery.Where(m => m.GarageId == garageId);
            }

            DateTime startDateTime;
            DateTime endDateTime;

            bool isStartDateValid = DateTime.TryParse(startDate, out startDateTime);
            bool isEndDateTimeValid = DateTime.TryParse(endDate, out endDateTime);

            if (!string.IsNullOrEmpty(startDate) && isStartDateValid)
            {
                if (!string.IsNullOrEmpty(endDate) && isEndDateTimeValid)
                {
                    if (startDateTime > endDateTime)
                    {
                        maintenanceQuery = maintenanceQuery.Where(m => m.ScheduledDate >= startDateTime && m.ScheduledDate <= endDateTime);
                    }
                }  
            }          
            
            var maintenances = await maintenanceQuery.ToListAsync();

            var responseMaintenances = maintenances.Select(m => new ResponseMaintenanceDto
            {
                Id = m.Id,
                CarId = m.CarId,
                CarName = m.CarName,
                GarageId = m.GarageId,
                GarageName = m.GarageName,
                ScheduledDate = m.ScheduledDate.ToString("yyyy-MM-dd"),
                ServiceType = m.ServiceType,
            }).ToList();

            return responseMaintenances;
        }

        public async Task<ResponseMaintenanceDto> GetMaintenanceById(int id)
        {
            var maintenanceDto = await _context.Maintenances
                .Where(m => m.Id == id)
                .Select(m => new ResponseMaintenanceDto
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    CarName = m.CarName,
                    GarageId = m.GarageId,
                    GarageName = m.GarageName,
                    ScheduledDate = m.ScheduledDate.ToString("yyyy-MM-dd"),
                    ServiceType = m.ServiceType,

                }).FirstOrDefaultAsync();

            return maintenanceDto;
        }

        public async Task<ResponseMaintenanceDto> CreateMaintenance(CreateMaintenanceDto maintenanceDto)
        {
            DateTime scheduledDate = new DateTime();
            DateTime.TryParseExact(maintenanceDto.ScheduledDate, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduledDate);

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == maintenanceDto.CarId);
            var garage = await _context.Garages.FirstOrDefaultAsync(g => g.Id == maintenanceDto.GarageId);

            var maintenance = new Maintenance
            {
                ServiceType = maintenanceDto.ServiceType,
                ScheduledDate = scheduledDate,
                CarId = maintenanceDto.CarId,
                GarageId = maintenanceDto.GarageId,
                Car = car,
                Garage = garage,
                CarName = car.Make,
                GarageName = garage.Name,
            };

            await _context.Maintenances.AddAsync(maintenance);
            await _context.SaveChangesAsync();

            return await GetMaintenanceById(maintenance.Id);
        }

        public async Task<ResponseMaintenanceDto> UpdateMaintenance(int id, UpdateMaintenanceDto maintenanceDto)
        {
            var maintenance = await _context.Maintenances.FirstOrDefaultAsync(m => m.Id == id);

            if (maintenance == null) 
            {
                return null;
            }

            DateTime scheduledDate = new DateTime();
            DateTime.TryParseExact(maintenanceDto.ScheduledDate, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduledDate);

            maintenance.ServiceType = maintenanceDto.ServiceType;
            maintenance.ScheduledDate = scheduledDate;
            maintenance.CarId = maintenanceDto.CarId;
            maintenance.GarageId = maintenance.GarageId;

            _context.Maintenances.Update(maintenance);
            await _context.SaveChangesAsync();

            return await GetMaintenanceById(maintenance.Id);
        }

        public async Task<bool> DeleteMaintenance(int id)
        {
            var maintenance = await _context.Maintenances
                .Include(m => m.Garage)
                .Include(m => m.Car)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (maintenance == null)
            {
                return false;
            }

            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
