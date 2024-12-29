namespace car_management_api.Services
{
    using car_management_api.Dtos;

    public interface IGarageService
    {
        Task<List<ResponseGarageDto>> GetAllGarages(string? city);
        Task<ResponseGarageDto> GetGarageById(int id);
        Task<ResponseGarageDto> UpdateGarage(int id, UpdateGarageDto garageDto);
        Task<bool> DeleteGarage(int id);
        Task<ResponseGarageDto> CreateGarage(CreateGarageDto garageDto);
    }
}
