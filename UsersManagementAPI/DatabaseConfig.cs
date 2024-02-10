using Microsoft.EntityFrameworkCore;
using UsersManagementAPI.Database;

public static class DatabaseConfig
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
    }
}
