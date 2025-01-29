using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_cinema_challenge.Data
{
    public class CinemaContext : DbContext
    {
        private string _connectionString;
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seeder = new Seeder();

            modelBuilder.Entity<Ticket>().HasKey(t => new { t.CustomerId, t.ScreeningId });
            modelBuilder.Entity<Ticket>().HasOne(c => c.Customer).WithMany(c => c.Tickets).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Ticket>().HasOne(s => s.Screening).WithMany(s => s.Tickets).HasPrincipalKey(s => new { s.MovieId, s.Id});

            modelBuilder.Entity<Screening>().HasOne(m => m.Movie).WithMany(m => m.Screenings).HasForeignKey(m => m.MovieId);


            modelBuilder.Entity<Customer>().HasData(seeder.CustomerList);
            modelBuilder.Entity<Ticket>().HasData(seeder.TicketList);
            modelBuilder.Entity<Movie>().HasData(seeder.MovieList);
            modelBuilder.Entity<Screening>().HasData(seeder.ScreeningList);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
