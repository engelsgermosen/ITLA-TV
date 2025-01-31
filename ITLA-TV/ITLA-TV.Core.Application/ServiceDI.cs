using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ITLA_TV.Core.Application
{
    public static class ServiceDI
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddTransient<ISerieService, SerieService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<IGenderService, GenderService>();
        }
    }
}
