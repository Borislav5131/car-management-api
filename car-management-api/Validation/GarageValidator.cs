namespace car_management_api.Validation
{
    using car_management_api.Dtos;
    using System.Globalization;

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

        public static List<string> ValidateDatesReport(string startDate, string endDate) 
        {
            var errors = new List<string>();

            DateTime startDateTime;
            bool isValidStartDate = DateTime.TryParseExact(startDate, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime);
            if (!isValidStartDate)
            {
                errors.Add("Start Date is not valid!");
            }

            DateTime endDateTime;
            bool isValidEndDate = DateTime.TryParseExact(endDate, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime);
            if (!isValidEndDate)
            {
                errors.Add("End Date is not valid!");
            }

            return errors;
        }
    }
}
