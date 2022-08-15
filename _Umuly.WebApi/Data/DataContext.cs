using _Umuly.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _Umuly.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteOwner> QuoteOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<City>()
                .HasOne<Country>(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(city => city.CountryId);

            modelBuilder.Entity<Quote>()
                        .HasOne<City>(q => q.FromCity)
                        .WithMany(c => c.FromCityQuotes)
                        .HasForeignKey(q => q.FromCityId);

            modelBuilder.Entity<Quote>().HasOne<City>(q => q.ToCity)
                                  .WithMany(c => c.ToCityQuotes).OnDelete(DeleteBehavior.NoAction)
                        .HasForeignKey(q => q.ToCityId);

            modelBuilder.Entity<Quote>().HasOne<Currency>(q => q.Currency)
                                  .WithMany(c => c.Quotes).HasForeignKey(q => q.CurrencyId);

            modelBuilder.Entity<Quote>().HasOne<QuoteOwner>(q => q.QuoteOwner)
                .WithMany(q => q.Quotes)
                .HasForeignKey(q => q.QuoteOwnerId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
