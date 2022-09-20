using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Extension;
using LocacaoVeiculo.Domain.Interfaces;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IOperadorRepository _operadorRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository
            , IOperadorRepository operadorRepository
            , IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _operadorRepository = operadorRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> ValidateCredentials(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.UserName.IsCPF())
            {
                usuarioDTO.UserName = usuarioDTO.UserName.FormatOnlyNumericCPF();
            }

            var usuario = await _usuarioRepository.ValidateCredentialsAsync(_mapper.Map<Usuario>(usuarioDTO));
            return _mapper.Map<UsuarioDTO>(usuario);
        }
        public async Task<UsuarioDTO> CreateUsuario(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.UserName.IsCPF())
            {
                usuarioDTO.UserName = usuarioDTO.UserName.FormatOnlyNumericCPF();
            }

            var usuario = await _usuarioRepository.CreateUsuarioAsync(_mapper.Map<Usuario>(usuarioDTO));
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<dynamic> GetUsuario(string key)
        {
            if (key.IsCPF())
            {
                var clienteEntity = await _clienteRepository.GetByCPFAsync(key);
                return _mapper.Map<ClienteDTO>(clienteEntity);
            } else
            {
                var operadorEntity = await _operadorRepository.GetByMatriculaAsync(key);
                return _mapper.Map<OperadorDTO>(operadorEntity);
            }
        }
    }
}
