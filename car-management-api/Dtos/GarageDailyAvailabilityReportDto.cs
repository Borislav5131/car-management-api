namespace car_management_api.Dtos
{
    public class GarageDailyAvailabilityReportDto
    {
        public string Date { get; set; }
        public int Requests { get; set; }
        public int AvailableCapacity { get; set; }
    }
}
