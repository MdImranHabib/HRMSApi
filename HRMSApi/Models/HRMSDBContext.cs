using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models
{
    public class HRMSDBContext:DbContext
    {
        public HRMSDBContext(DbContextOptions<HRMSDBContext> options):base(options)
        {

        }

        public DbSet<Flat> Flats { get; set; }
    }
}
