using LocacaoVeiculo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> GetByCPFAsync(string CPF);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<Cliente> UpdateAsync(Cliente cliente);
        Task<Cliente> RemoveAsync(Cliente cliente);
        Task<bool> Exists(string CPF);
    }
}
