namespace car_management_api.Services
{
    using car_management_api.Models;

    public interface IGarageService
    {
        Task<List<Garage>> GetAllGarages(string? city);
    }
}
