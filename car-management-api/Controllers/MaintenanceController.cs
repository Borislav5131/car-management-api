namespace car_management_api.Controllers
{
    using car_management_api.Dtos;
    using car_management_api.Services;
    using car_management_api.Validation;
    using Microsoft.AspNetCore.Mvc;

    [Route("maintenance")]
    [ApiController]
    public class MaintenanceController : Controller
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaintenances(int? carId, int? garageId, string? startDate, string? endDate)
        {
            var maintenances = await _maintenanceService.GetAllMaintenances(carId, garageId, startDate, endDate);

            if (maintenances == null || maintenances.Count == 0) 
            {
                return BadRequest("No maintenances found!");
            }

            return Ok(maintenances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenanceById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid maintenance ID!");
            }

            var maintenance = await _maintenanceService.GetMaintenanceById(id);

            if (maintenance == null)
            {
                return NotFound("No maintenance found!");
            }

            return Ok(maintenance);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenance(CreateMaintenanceDto maintenanceDto)
        {
            var validationErrors = MaintenanceValidator.ValidateCreateMaintenanceDto(maintenanceDto);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var createdMaintenance = await _maintenanceService.CreateMaintenance(maintenanceDto);

            if(createdMaintenance == null)
            {
                return BadRequest("Maintenance not created!");
            }

            return Ok(createdMaintenance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMaintenance(int id, UpdateMaintenanceDto maintenanceDto)
        {
            var validationErrors = MaintenanceValidator.ValidateUpdateMaintenanceDto(maintenanceDto);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var updatedMaintenance = await _maintenanceService.UpdateMaintenance(id, maintenanceDto);

            if (updatedMaintenance == null)
            {
                return NotFound($"Maintenance with ID {id} not found!");
            }

            return Ok(updatedMaintenance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenance(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid maintenance ID!");
            }

            var isDeleted = await _maintenanceService.DeleteMaintenance(id);

            if (!isDeleted)
            {
                return NotFound("Maintenance deleted unsuccessfully!");
            }

            return Ok("Maintenance deleted successfully!");
        }

        [HttpGet("monthlyRequestsReport")]
        public async Task<IActionResult> GetReport(int garageId, string startMonth, string endMonth)
        {
            var validationErrors = MaintenanceValidator.ValidateMonthReport(startMonth, endMonth);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var reports = await _maintenanceService.GetMonthlyRequestsReport(garageId, startMonth, endMonth);

            if (reports == null || reports.Count == 0)
            {
                return BadRequest("Can't get reports!");
            }

            return Ok(reports);
        }
    }
}
