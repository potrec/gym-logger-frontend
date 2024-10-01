using gym_logger_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace gym_logger_backend.Migrations
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using ApplicationDBContext context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            context.Database.Migrate();
        }
    }
}
