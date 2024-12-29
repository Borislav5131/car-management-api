namespace car_management_api.Dtos
{
    public class CreateCarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string LicensePlate { get; set; }
        public List<int> GarageIds { get; set; }
    }
}
