using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class AddAppServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, 
    IConfiguration config)
    {
        //DBContext Injection
        services.AddDbContext<DBContext>(option =>
        {
            option.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        //Angular part
        services.AddCors();

        //Injection of Token Service
        services.AddScoped<ITokenService,TokenService>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
