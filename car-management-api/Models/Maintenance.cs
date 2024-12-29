namespace car_management_api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Maintenance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ServiceType { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        public string CarName { get; set; }
        public string GarageName { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [ForeignKey("Garage")]
        public int GarageId { get; set; }

        public Garage Garage { get; set; }
    }
}
