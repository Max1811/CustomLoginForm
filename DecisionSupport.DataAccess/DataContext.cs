using DecisionSupport.DataAccess.Entities;
using DecisionSupport.DataAccess.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DecisionSupport.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<OrderedAlternative> OrderedAlternatives { get; set; }
        public DbSet<Voting> Votings { get; set; }
        public DbSet<VotingResult> VotingResults { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AlternativeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderedAlternativeConfiguration());
            modelBuilder.ApplyConfiguration(new VotingConfiguration());
            modelBuilder.ApplyConfiguration(new VotingResultConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MSSQLLocalConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
