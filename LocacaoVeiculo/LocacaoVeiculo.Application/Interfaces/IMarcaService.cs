using LocacaoVeiculo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDTO>> GetMarcas();
        Task<MarcaDTO> GetById(int id);
        Task<MarcaDTO> Add(MarcaDTO marcaDto);
        Task Update(MarcaDTO marcaDto);
        Task Remove(int id);
    }
}
