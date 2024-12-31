using car_management_api.Dtos;
using car_management_api.Models;
using car_management_api.Services;
using car_management_api.Validation;
using Microsoft.AspNetCore.Mvc;

namespace car_management_api.Controllers
{
    [Route("garages")]
    [ApiController]
    public class GarageController : Controller
    {
        private readonly IGarageService _garageService;

        public GarageController(IGarageService garageService)
        {
            _garageService = garageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGarages(string? city)
        {
            var garages = await _garageService.GetAllGarages(city);

            if (garages == null || garages.Count == 0)
            {
                return BadRequest("No garages found!");
            }

            return Ok(garages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGarageById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid garage ID!");
            }

            var garage = await _garageService.GetGarageById(id);

            if (garage == null)
            {
                return NotFound("No garage found!");
            }

            return Ok(garage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGarage(CreateGarageDto garageDto)
        {
            var validationErrors = GarageValidator.ValidateCreateGarageDto(garageDto);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var createdGarage = await _garageService.CreateGarage(garageDto);

            if (createdGarage == null)
            {
                return BadRequest($"Garage not created!");
            }

            return Ok(createdGarage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditGarage(int id, UpdateGarageDto garageDto)
        {
            var validationErrors = GarageValidator.ValidateUpdateGarageDto(garageDto);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var updatedGarage = await _garageService.UpdateGarage(id, garageDto);

            if (updatedGarage == null)
            {
                return NotFound($"Garage with ID {id} not found!");
            }

            return Ok(updatedGarage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid garage ID!");
            }

            var isDeleted = await _garageService.DeleteGarage(id);

            if (!isDeleted)
            {
                return NotFound("Garage deleted unsuccessfully!");
            }

            return Ok("Garage deleted successfully!");
        }

        [HttpGet("dailyAvailabilityReport")]
        public async Task<IActionResult> GetReport(int garageId, string startDate, string endDate)
        {
            var validationErrors = GarageValidator.ValidateDatesReport(startDate, endDate);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var reports = await _garageService.GetDailyAvailabilityReport(garageId, startDate, endDate);

            if (reports == null || reports.Count == 0)
            {
                return BadRequest("Can't get reports!");
            }

            return Ok(reports);
        }
    }
}
