using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using TesteTecnicoTechNation.Domain.Interfaces.Repositories;
using TesteTecnicoTechNation.Application.Interfaces;
using TesteTecnicoTechNation.Application.Services;
using TesteTecnicoTechNation.Application.Mappings;
using TesteTecnicoTechNation.Infra.Data.Repositories;

namespace TesteTecnicoTechNation.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            {
                services.AddTransient<IDbConnection>(sp =>
                    new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
                services.AddScoped<INotaFiscalService, NotaFiscalService>();

                services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

                return services;
            }
        }
    }
}
