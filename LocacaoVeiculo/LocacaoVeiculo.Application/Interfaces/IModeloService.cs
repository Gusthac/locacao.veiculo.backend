using LocacaoVeiculo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<ModeloDTO>> GetModelos();
        Task<ModeloDTO> GetById(int id);
        Task<ModeloDTO> Add(ModeloDTO modeloDto);
        Task Update(ModeloDTO modeloDto);
        Task Remove(int id);
    }
}
