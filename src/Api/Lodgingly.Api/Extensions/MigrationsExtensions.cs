using Microsoft.EntityFrameworkCore;

namespace Lodgingly.Api.Extensions;

public static class MigrationsExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder application)
    {
        using IServiceScope scope = application.ApplicationServices.CreateScope();
        
        // Add db migrations to apply for modules below this point
        // ApplyMigration<ModuleDbContext>(scope);
    }

    private static void ApplyMigration<TDatabaseContext>(IServiceScope scope)
        where TDatabaseContext : DbContext
    {
        using TDatabaseContext context = scope.ServiceProvider.GetRequiredService<TDatabaseContext>();
        context.Database.Migrate();
    }
}