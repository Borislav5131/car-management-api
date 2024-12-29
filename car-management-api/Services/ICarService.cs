namespace car_management_api.Services
{
    using car_management_api.Dtos;

    public interface ICarService
    {
        Task<List<ResponseCarDto>> GetAllCars(string? carMake, int? garageId, int? fromYear, int? toYear);
        Task<ResponseCarDto> GetCarById(int id);
        Task<ResponseCarDto> UpdateCar(int id, UpdateCarDto carDto);
        Task<bool> DeleteCar(int id);
        Task<ResponseCarDto> CreateCar(CreateCarDto carDto);
    }
}
