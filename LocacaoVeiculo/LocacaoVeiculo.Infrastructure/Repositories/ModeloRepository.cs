using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using LocacaoVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly ApplicationDbContext _modeloContext;
        public ModeloRepository(ApplicationDbContext context)
        {
            _modeloContext = context;
        }
        public async Task<Modelo> CreateAsync(Modelo modelo)
        {
            _modeloContext.Add(modelo);
            await _modeloContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Modelo> GetByIdAsync(int id)
        {
            return await _modeloContext.Modelos.FindAsync(id);
        }

        public async Task<IEnumerable<Modelo>> GetModelosAsync()
        {
            return await _modeloContext.Modelos.ToListAsync();
        }

        public async Task<Modelo> RemoveAsync(Modelo modelo)
        {
            _modeloContext.Remove(modelo);
            await _modeloContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Modelo> UpdateAsync(Modelo modelo)
        {
            _modeloContext.Update(modelo);
            await _modeloContext.SaveChangesAsync();
            return modelo;
        }
    }
}
