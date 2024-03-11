using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-G16KCG0\\SQLEXPRESS; Database=HotelDb; TrustServerCertificate=True; MultipleActiveResultSets=true;Integrated Security=SSPI;");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
