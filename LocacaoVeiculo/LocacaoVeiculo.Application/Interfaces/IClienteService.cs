using LocacaoVeiculo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientes();
        Task<ClienteDTO> GetById(int id);
        Task<ClienteDTO> GetByCPF(string CPF);
        Task<ClienteDTO> Add(ClienteDTO clienteDto);
        Task Update(ClienteDTO clienteDto);
        Task Remove(int id);
        Task<bool> ExistsCPF(string CPF);
    }
}
