using LocacaoVeiculo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Domain.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcasAsync();
        Task<Marca> GetByIdAsync(int id);
        Task<Marca> CreateAsync(Marca marca);
        Task<Marca> UpdateAsync(Marca marca);
        Task<Marca> RemoveAsync(Marca marca);
    }
}
