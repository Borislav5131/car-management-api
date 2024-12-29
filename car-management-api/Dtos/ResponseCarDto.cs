namespace car_management_api.Dtos
{
    public class ResponseCarDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string LicensePlate { get; set; }
        public List<ResponseGarageDto> Garages { get; set; }
    }
}
