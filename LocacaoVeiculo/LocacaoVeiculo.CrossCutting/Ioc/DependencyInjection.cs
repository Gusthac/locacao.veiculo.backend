using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Application.Mappings;
using LocacaoVeiculo.Application.Services;
using LocacaoVeiculo.Domain.Interfaces;
using LocacaoVeiculo.Infrastructure.Context;
using LocacaoVeiculo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocacaoVeiculo.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IOperadorService, OperadorService>();

            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddScoped<IAtividadeService, AtividadeService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
