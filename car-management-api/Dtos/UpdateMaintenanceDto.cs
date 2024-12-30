namespace car_management_api.Dtos
{
    public class UpdateMaintenanceDto
    {
        public int CarId { get; set; }
        public string ServiceType { get; set; }
        public string ScheduledDate { get; set; }
        public int GarageId { get; set; }
    }
}
