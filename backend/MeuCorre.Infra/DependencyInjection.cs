﻿using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.Infra.Data.Context;
using MeuCorre.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Mysql");

        services.AddDbContext<MeuDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // ✅ Registro do repositório
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();

        return services;
    }
}
