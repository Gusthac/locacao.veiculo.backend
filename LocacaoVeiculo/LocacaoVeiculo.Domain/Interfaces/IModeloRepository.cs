using LocacaoVeiculo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Domain.Interfaces
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetModelosAsync();
        Task<Modelo> GetByIdAsync(int id);
        Task<Modelo> CreateAsync(Modelo modelo);
        Task<Modelo> UpdateAsync(Modelo modelo);
        Task<Modelo> RemoveAsync(Modelo modelo);
    }
}
