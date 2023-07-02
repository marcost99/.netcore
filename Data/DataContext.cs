using Microsoft.EntityFrameworkCore;
using donations.Models;

namespace donations.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Donation> Donations { get; set; }
    }
}