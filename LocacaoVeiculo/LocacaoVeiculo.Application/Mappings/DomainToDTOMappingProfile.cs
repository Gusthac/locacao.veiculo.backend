using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Domain.Entities;

namespace LocacaoVeiculo.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Operador, OperadorDTO>().ReverseMap();
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Modelo, ModeloDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
        }
    }
}