namespace car_management_api.Dtos
{
    public class CreateMaintenanceDto
    {
        public int GarageId { get; set; }
        public int CarId { get; set; }
        public string ServiceType { get; set; }
        public string ScheduledDate { get; set; }
    }
}
