using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using LocacaoVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _clienteContext;
        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }
        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetByCPFAsync(string CPF)
        {
            return await _clienteContext.Clientes.SingleOrDefaultAsync(p => (p.CPF == CPF));
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _clienteContext.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> RemoveAsync(Cliente cliente)
        {
            _clienteContext.Remove(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _clienteContext.Update(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> Exists(string CPF)
        {
            return await _clienteContext.Clientes.AnyAsync(p => p.CPF.Equals(CPF));
        }
    }
}
