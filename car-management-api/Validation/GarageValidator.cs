namespace car_management_api.Validation
{
    using car_management_api.Dtos;

    public class GarageValidator
    {
        public static List<string> ValidateUpdateGarageDto(UpdateGarageDto garageDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(garageDto.Name))
            {
                errors.Add("Name is required!");
            }

            if (string.IsNullOrEmpty(garageDto.City))
            {
                errors.Add("City is required!");
            }

            if (string.IsNullOrEmpty(garageDto.Location))
            {
                errors.Add("Location is required!");
            }

            if (garageDto.Capacity <= 0)
            {
                errors.Add("Capacity must be greater than 0!");
            }

            return errors;
        }

        public static List<string> ValidateCreateGarageDto(CreateGarageDto garageDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(garageDto.Name))
            {
                errors.Add("Name is required!");
            }

            if (string.IsNullOrEmpty(garageDto.City))
            {
                errors.Add("City is required!");
            }

            if (string.IsNullOrEmpty(garageDto.Location))
            {
                errors.Add("Location is required!");
            }

            if (garageDto.Capacity <= 0)
            {
                errors.Add("Capacity must be greater than 0!");
            }

            return errors;
        }
    }
}
