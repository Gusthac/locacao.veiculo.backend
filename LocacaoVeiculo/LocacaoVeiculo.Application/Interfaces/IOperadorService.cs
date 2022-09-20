using LocacaoVeiculo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IOperadorService
    {
        Task<IEnumerable<OperadorDTO>> GetOperadores();
        Task<OperadorDTO> GetByMatricula(string matricula);
        Task<OperadorDTO> Add(OperadorDTO operadorDto);
        Task Update(OperadorDTO operadorDto);
        Task Remove(string matricula);
    }
}
