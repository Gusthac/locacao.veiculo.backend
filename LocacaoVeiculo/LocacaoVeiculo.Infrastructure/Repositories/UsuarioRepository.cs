using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using LocacaoVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _usuarioContext;
        public UsuarioRepository(ApplicationDbContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }

        public async Task<Usuario> ValidateCredentialsAsync(Usuario usuario)
        {
            return await _usuarioContext.Usuarios.FirstOrDefaultAsync(u => (u.UserName == usuario.UserName) && (u.Password == usuario.Password));
        }
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }
    }
}
