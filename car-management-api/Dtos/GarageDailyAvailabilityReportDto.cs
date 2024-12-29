namespace car_management_api.Dtos
{
    public class GarageDailyAvailabilityReportDto
    {
        public DateTime Date { get; set; }
        public int Requests { get; set; }
        public int AvailableCapacity { get; set; }
    }
}
