using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedWalker.Core.Domains.Accidents.Repositories;
using RedWalker.Core.Domains.Directories.Repositories;
using RedWalker.Core.Domains.Items.Repositories;
using RedWalker.Data.Accidents.Repositories;
using RedWalker.Data.Directories.Repositories;
using RedWalker.Data.Items.Repositories;

namespace RedWalker.Data;

public static class Bootstrap
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccidentRepository, AccidentRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ITypeAccidentRepository, TypeAccidentRepository>();
        services.AddDbContext<RedWalkerContext>(options => options.UseSqlite(
            configuration["DataSource"]
        ));
        return services;
    }
}