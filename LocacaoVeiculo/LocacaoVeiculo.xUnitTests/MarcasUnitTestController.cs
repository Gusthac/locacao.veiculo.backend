using AutoMapper;
using LocacaoVeiculo.API.Controllers;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Application.Mappings;
using LocacaoVeiculo.Application.Services;
using LocacaoVeiculo.Infrastructure.Context;
using LocacaoVeiculo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace LocacaoVeiculo.xUnitTests
{
    public class MarcasUnitTestController
    {
        private IMarcaService _marcaService;
        private IMapper mapper;

        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }

        public static string connectionString = "Server=localhost;DataBase=LocacaoVeiculoAPIDB;Uid=root;Pwd=root";

        static MarcasUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
        }

        public MarcasUnitTestController()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            var repository = new MarcaRepository(context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(DomainToDTOMappingProfile));
            });
            mapper = config.CreateMapper();

            _marcaService = new MarcaService(repository, mapper);
        }

        [Fact]
        public void GetMarcasById_Return_OkResult()
        {
            //Arrange  
            var controller = new MarcasController(_marcaService);
            var marcaId = 2;

            //Act  
            var data = controller.Get(marcaId);
            Console.WriteLine(data);

            //Assert  
            Assert.IsType<MarcaDTO>(data);
        }
    }
}
