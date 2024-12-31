namespace car_management_api.Services
{
    using car_management_api.Dtos;

    public interface IMaintenanceService
    {
        Task<List<ResponseMaintenanceDto>> GetAllMaintenances(int? carId, int? garageId, string? startDate, string? endDate);
        Task<ResponseMaintenanceDto> GetMaintenanceById(int id);
        Task<ResponseMaintenanceDto> UpdateMaintenance(int id, UpdateMaintenanceDto maintenanceDto);
        Task<bool> DeleteMaintenance(int id);
        Task<ResponseMaintenanceDto> CreateMaintenance(CreateMaintenanceDto maintenanceDto);
        Task<List<MonthlyRequestsReportDto>> GetMonthlyRequestsReport(int garageId, string startDate, string endDate);
    }
}
