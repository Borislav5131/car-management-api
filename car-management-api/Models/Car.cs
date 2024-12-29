namespace car_management_api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int ProductionYear { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        public List<Garage> Garages { get; set; }

        public List<Maintenance> Maintenances { get; set; }
    }
}
