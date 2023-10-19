using Core.Interfaces;
using Dal.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal;

public static class ForStartup
{
    public static IServiceCollection AddDal(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<AppGameContext>(opt => opt.UseNpgsql(connectionString))
                       .AddTransient<IDbRepository, GameRepository>();
    }
}
