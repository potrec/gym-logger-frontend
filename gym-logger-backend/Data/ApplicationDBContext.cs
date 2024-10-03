using gym_logger_backend.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace gym_logger_backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserBodyMeasurement> UserBodyMeasurements { get; set; }
        private readonly ILogger<ApplicationDBContext> _logger;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions, ILogger<ApplicationDBContext> logger): base(dbContextOptions)
        {
            _logger = logger;

            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
                {
                    if (!databaseCreator.HasTables())
                    {
                        _logger.LogInformation("No tables found, applying migrations...");
                        Database.Migrate();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserBodyMeasurements)
                .WithOne(ub => ub.User)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDetails)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDetails>(ud => ud.UserId);
        }
    }
}
