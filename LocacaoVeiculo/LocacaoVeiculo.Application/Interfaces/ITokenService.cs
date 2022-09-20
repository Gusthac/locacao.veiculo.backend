using LocacaoVeiculo.Application.DTOs;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface ITokenService
    {
        TokenDTO GenerateToken(UsuarioDTO usuario);
    }
}
