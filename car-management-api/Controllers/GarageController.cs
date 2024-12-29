using car_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace car_management_api.Controllers
{
    [Route("/garages")]
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
                return NotFound("No garages found.");
            }

            return Ok(garages);
        }
    }
}
