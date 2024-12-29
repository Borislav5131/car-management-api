namespace car_management_api.Services
{
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

        public async Task<List<Garage>> GetAllGarages(string? city)
        {
            var garagesQuery = _context.Garages.AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                garagesQuery = garagesQuery.Where(g => g.City.ToLower() == city.ToLower());
            }

            var garages = await garagesQuery.ToListAsync();

            return garages;
        }
    }
}
