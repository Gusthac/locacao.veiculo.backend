using LocacaoVeiculo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoDTO>> GetVeiculos();
        Task<VeiculoDTO> GetById(int id);
        Task<VeiculoDTO> Add(VeiculoDTO veiculoDto);
        Task Update(VeiculoDTO veiculoDto);
        Task Remove(int id);
    }
}
