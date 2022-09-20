using LocacaoVeiculo.Domain.Entities;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ValidateCredentialsAsync(Usuario usuario);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    }
}
