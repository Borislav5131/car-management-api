namespace car_management_api.Validation
{
    using car_management_api.Dtos;
    using System;

    public class CarValidator
    {
        public static List<string> ValidateUpdateCarDto(UpdateCarDto carDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(carDto.Make))
            {
                errors.Add("Make is required!");
            }

            if (string.IsNullOrEmpty(carDto.Model))
            {
                errors.Add("Model is required!");
            }

            if (carDto.ProductionYear <= 0)
            {
                errors.Add("Production Year must be greater than 0!");
            }

            if (string.IsNullOrEmpty(carDto.LicensePlate))
            {
                errors.Add("LicensePlate is required!");
            }

            if (carDto.GarageIds.Any(gi => gi <= 0))
            {
                errors.Add("Garage Ids must be greater than 0!");
            }

            return errors;
        }

        public static List<string> ValidateCreateCarDto(CreateCarDto carDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(carDto.Make))
            {
                errors.Add("Make is required!");
            }

            if (string.IsNullOrEmpty(carDto.Model))
            {
                errors.Add("Model is required!");
            }

            if (carDto.ProductionYear <= 0)
            {
                errors.Add("Production Year must be greater than 0!");
            }

            if (string.IsNullOrEmpty(carDto.LicensePlate))
            {
                errors.Add("LicensePlate is required!");
            }

            if (carDto.GarageIds.Any(gi => gi <= 0))
            {
                errors.Add("Garage Ids must be greater than 0!");
            }

            return errors;
        }
    }
}
