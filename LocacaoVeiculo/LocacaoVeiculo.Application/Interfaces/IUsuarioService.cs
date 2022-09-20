using LocacaoVeiculo.Application.DTOs;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> ValidateCredentials(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> CreateUsuario(UsuarioDTO usuarioDTO);
        Task<dynamic> GetUsuario(string key);
    }
}
