using Microsoft.Extensions.DependencyInjection;
using RedWalker.Core.Domains.Accidents.Services;
using RedWalker.Core.Domains.Directories.Services;
using RedWalker.Core.Domains.Items.Services;

namespace RedWalker.Core
{
    public static class Bootstraps
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IAccidentService, AccidentService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ITypeAccidentService, TypeAccidentService>();
            return services;
        }
    }
}