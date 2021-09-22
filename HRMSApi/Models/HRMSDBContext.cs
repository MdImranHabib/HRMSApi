using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMSApi.Models;

namespace HRMSApi.Models
{
    public class HRMSDBContext:DbContext
    {
        public HRMSDBContext(DbContextOptions<HRMSDBContext> options):base(options)
        {

        }

        public DbSet<Flat> Flats { get; set; }

        public DbSet<HRMSApi.Models.Resident> Residents { get; set; }

        public DbSet<HRMSApi.Models.ResidentFlat> ResidentFlats { get; set; }

        public DbSet<HRMSApi.Models.Rent> Rents { get; set; }
    }
}
