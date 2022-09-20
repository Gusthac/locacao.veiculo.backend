using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using LocacaoVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Infrastructure.Repositories
{
    public class OperadorRepository : IOperadorRepository
    {
        private readonly ApplicationDbContext _operadorContext;
        public OperadorRepository(ApplicationDbContext context)
        {
            _operadorContext = context;
        }

        public async Task<Operador> CreateAsync(Operador operador)
        {
            _operadorContext.Add(operador);
            await _operadorContext.SaveChangesAsync();
            return operador;
        }

        public async Task<Operador> GetByMatriculaAsync(string matricula)
        {
            return await _operadorContext.Operadores.FindAsync(matricula);
        }

        public async Task<IEnumerable<Operador>> GetOperadoresAsync()
        {
            return await _operadorContext.Operadores.ToListAsync();
        }

        public async Task<Operador> RemoveAsync(Operador operador)
        {
            _operadorContext.Remove(operador);
            await _operadorContext.SaveChangesAsync();
            return operador;
        }

        public async Task<Operador> UpdateAsync(Operador operador)
        {
            _operadorContext.Update(operador);
            await _operadorContext.SaveChangesAsync();
            return operador;
        }
        public async Task<bool> Exists(string matricula)
        {
            return await _operadorContext.Operadores.AnyAsync(p => p.Matricula.Equals(matricula));
        }
    }
}
