using LocacaoVeiculo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetVeiculosAsync();
        Task<Veiculo> GetByIdAsync(int id);
        Task<IEnumerable<Veiculo>> GetByCategoriaAsync(string categoria);
        Task<Veiculo> CreateAsync(Veiculo veiculo);
        Task<Veiculo> UpdateAsync(Veiculo veiculo);
        Task<Veiculo> RemoveAsync(Veiculo veiculo);
    }
}
