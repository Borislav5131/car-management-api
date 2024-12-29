namespace car_management_api.Controllers
{
    using car_management_api.Dtos;
    using car_management_api.Services;
    using car_management_api.Validation;
    using Microsoft.AspNetCore.Mvc;

    [Route("cars")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars(string? carMake, int? garageId, int? fromYear, int? toYear)
        {
            var cars = await _carService.GetAllCars(carMake, garageId, fromYear, toYear);

            if (cars == null || cars.Count == 0)
            {
                return BadRequest("No cars found!");
            }

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid car ID!");
            }

            var car = await _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound("No car found!");
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto carDto)
        {
            var validationErrors = CarValidator.ValidateCreateCarDto(carDto);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var createdCar = await _carService.CreateCar(carDto);

            if (createdCar == null)
            {
                return BadRequest("Car not created!");
            }

            return Ok(createdCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCar(int id, UpdateCarDto carDto)
        {
            var validationErrors = CarValidator.ValidateUpdateCarDto(carDto);
            if (validationErrors.Count > 0)
            {
                return BadRequest(new { message = "Validation failed!", errors = validationErrors });
            }

            var updatedCar = await _carService.UpdateCar(id, carDto);

            if (updatedCar == null)
            {
                return NotFound($"Car with ID {id} not found!");
            }

            return Ok(updatedCar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid car ID!");
            }

            var isDeleted = await _carService.DeleteCar(id);

            if (!isDeleted)
            {
                return NotFound("Car deleted unsuccessfully!");
            }

            return Ok("Car deleted successfully!");
        }
    }
}
