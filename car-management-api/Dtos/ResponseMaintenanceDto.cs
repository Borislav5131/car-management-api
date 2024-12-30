namespace car_management_api.Dtos
{
    public class ResponseMaintenanceDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string ServiceType { get; set; }
        public string ScheduledDate { get; set; }
        public int GarageId { get; set; }
        public string GarageName { get; set; }
    }
}
