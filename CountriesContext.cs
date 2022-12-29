
using Microsoft.EntityFrameworkCore;
using Countrys_API.Models;

namespace Countrys_API
{
    public class CountriesContext : DbContext
    {

        public DbSet<Country> countries { get; set; }

        public CountriesContext(DbContextOptions<CountriesContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>( c => {

                c.ToTable("Country");

                c.Property(c => c.Id).ValueGeneratedNever();

                c.Property(c => c.Name).IsRequired(false);

                c.Property(c => c.Capital).IsRequired(false);

                c.Property(c => c.Flag).IsRequired(false);

                c.Property(c => c.Silhouette).IsRequired(false);

                c.Property(c => c.Population);

                c.Property(c => c.Superficie);

                c.Property(c => c.Continent).IsRequired(false);

                c.Property(c => c.PIB);

            });
        }
    }
}
