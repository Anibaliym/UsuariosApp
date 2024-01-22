using Microsoft.EntityFrameworkCore;
using Usuarios.Infra.Data.PostgreSQL.Context;

namespace Usuarios.Service.Api.Configurtions
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<UsuariosContext>(options => options.UseNpgsql(configuration.GetConnectionString("UsuariosConnection")));
            services.AddDbContext<EventStoreSqlContext>(options => options.UseNpgsql(configuration.GetConnectionString("UsuariosConnection")));
        }
    }
}
