using LocacaoVeiculo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Domain.Interfaces
{
    public interface IOperadorRepository
    {
        Task<IEnumerable<Operador>> GetOperadoresAsync();
        Task<Operador> GetByMatriculaAsync(string matricula);
        Task<Operador> CreateAsync(Operador operador);
        Task<Operador> UpdateAsync(Operador operador);
        Task<Operador> RemoveAsync(Operador operador);
        Task<bool> Exists(string matricula);
    }
}
