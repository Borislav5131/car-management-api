namespace car_management_api.Validation
{
    using car_management_api.Dtos;
    using System.Globalization;

    public class MaintenanceValidator
    {
        public static List<string> ValidateUpdateMaintenanceDto(UpdateMaintenanceDto maintenanceDto)
        {
            var errors = new List<string>();

            if (maintenanceDto.CarId <= 0)
            {
                errors.Add("Car Id must be greater than 0!");
            }

            if (maintenanceDto.GarageId <= 0)
            {
                errors.Add("Garage Id must be greater than 0!");
            }

            if (string.IsNullOrEmpty(maintenanceDto.ServiceType))
            {
                errors.Add("Service Type is required!");
            }

            DateTime scheduledDate;
            bool isValidScheduledDate = DateTime.TryParseExact(maintenanceDto.ScheduledDate, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduledDate);
            if (!isValidScheduledDate)
            {
                errors.Add("Scheduled Date is not valid!");
            }

            return errors;
        }

        public static List<string> ValidateCreateMaintenanceDto(CreateMaintenanceDto maintenanceDto)
        {
            var errors = new List<string>();

            if (maintenanceDto.CarId <= 0)
            {
                errors.Add("Car Id must be greater than 0!");
            }

            if (maintenanceDto.GarageId <= 0)
            {
                errors.Add("Garage Id must be greater than 0!");
            }

            if (string.IsNullOrEmpty(maintenanceDto.ServiceType))
            {
                errors.Add("Service Type is required!");
            }

            DateTime scheduledDate;
            bool isValidScheduledDate = DateTime.TryParseExact(maintenanceDto.ScheduledDate, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduledDate);
            if (!isValidScheduledDate)
            {
                errors.Add("Scheduled Date is not valid!");
            }

            return errors;
        }
    }
}
