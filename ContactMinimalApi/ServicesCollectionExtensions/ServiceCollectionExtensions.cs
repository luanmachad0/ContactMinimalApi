
using ContactMinimalApi.Infra;
using Microsoft.OpenApi.Models;
using Npgsql;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwagger();
        return builder;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
            });
        });
        return services;
    }

    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnectionString")
          ?? "Data Source=Contacts.db";

        builder.Services.AddNpgsql<ContactDbContext>(connectionString);

        builder.Services.AddScoped(_ => new NpgsqlConnection(connectionString));

        return builder;
    }
}