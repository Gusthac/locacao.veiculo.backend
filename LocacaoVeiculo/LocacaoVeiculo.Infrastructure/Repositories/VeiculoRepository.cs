using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using LocacaoVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Infrastructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ApplicationDbContext _veiculoContext;
        public VeiculoRepository(ApplicationDbContext context)
        {
            _veiculoContext = context;
        }
        public async Task<Veiculo> CreateAsync(Veiculo veiculo)
        {
            _veiculoContext.Add(veiculo);
            await _veiculoContext.SaveChangesAsync();
            return veiculo;
        }

        public async Task<IEnumerable<Veiculo>> GetByCategoriaAsync(string categoria)
        {
            var veiculos = await _veiculoContext.Veiculos.ToListAsync();
            var filtrados = veiculos.FindAll(p => p.Categoria == categoria);
            return filtrados;
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _veiculoContext.Veiculos.FindAsync(id);
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculosAsync()
        {
            return await _veiculoContext.Veiculos.ToListAsync();
        }

        public async Task<Veiculo> RemoveAsync(Veiculo veiculo)
        {
            _veiculoContext.Remove(veiculo);
            await _veiculoContext.SaveChangesAsync();
            return veiculo;
        }

        public async Task<Veiculo> UpdateAsync(Veiculo veiculo)
        {
            _veiculoContext.Update(veiculo);
            await _veiculoContext.SaveChangesAsync();
            return veiculo;
        }
    }
}
