using Microsoft.EntityFrameworkCore;

namespace HRMSApi.Models
{
    public class HRMSDBContext:DbContext
    {
        public HRMSDBContext(DbContextOptions<HRMSDBContext> options):base(options)
        {

        }

        public DbSet<HRMSApi.Models.Flat> Flats { get; set; }
        public DbSet<HRMSApi.Models.Resident> Residents { get; set; }
        public DbSet<HRMSApi.Models.ResidentFlat> ResidentFlats { get; set; }
        public DbSet<HRMSApi.Models.Rent> Rents { get; set; }
        public DbSet<HRMSApi.Models.User> Users { get; set; }
        public DbSet<HRMSApi.Models.Role> Roles { get; set; }
        public DbSet<HRMSApi.Models.UserRole> UserRoles { get; set; }
    }
}
