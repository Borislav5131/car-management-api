namespace car_management_api.Dtos
{
    public class CreateGarageDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
    }
}
