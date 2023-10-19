using Logic.Game;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public static class ForStartup
{
    public static IServiceCollection AddLogic(this IServiceCollection services)
    { 
        return services.AddAutoMapper(typeof(GameProfile))
                       .AddTransient<GameManager>();
    }
}
