namespace car_management_api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Garage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Capacity { get; set; }

        public List<Car> Cars { get; set; }
    }
}
