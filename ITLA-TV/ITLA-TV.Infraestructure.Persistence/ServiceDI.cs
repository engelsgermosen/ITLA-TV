using ITLA_TV.Core.Application.Interfaces.Repositories;
using ITLA_TV.Infraestructure.Persistence.Contexts;
using ITLA_TV.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITLA_TV.Infraestructure.Persistence
{
    public static class ServiceDI
    {
        public static void AddPersistenceDI(this IServiceCollection services, IConfiguration config)
        {
            #region "Db config"
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(config.GetConnectionString("conexion"), m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            #endregion

            #region "Repositories DI"

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ISerieRepository, SerieRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();

            #endregion
        }
    }
}
