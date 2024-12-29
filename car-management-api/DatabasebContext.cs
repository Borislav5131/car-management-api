using car_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace car_management_api
{
    public class DatabasebContext : DbContext
    {
        public DatabasebContext(DbContextOptions<DatabasebContext> options)
        : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
    }
}
