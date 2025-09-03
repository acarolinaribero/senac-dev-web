using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Infra
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           var connectionString = configuration.GetConnectionString("Mysql");
            services.AddDbContext<Context.MeuDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }

    }
}
