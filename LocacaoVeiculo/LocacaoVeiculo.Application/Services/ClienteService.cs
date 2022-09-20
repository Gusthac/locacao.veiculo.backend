using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Extension;
using LocacaoVeiculo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<ClienteDTO> Add(ClienteDTO clienteDto)
        {
            if (clienteDto.CPF.IsCPF())
            {
                clienteDto.CPF = clienteDto.CPF.FormatOnlyNumericCPF();
            }

            var clienteEntity = _mapper.Map<Cliente>(clienteDto);
            var cliente = await _clienteRepository.CreateAsync(clienteEntity);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> GetByCPF(string CPF)
        {
            if (CPF.IsCPF())
            {
                CPF = CPF.FormatOnlyNumericCPF();
            }

            var clienteEntity = await _clienteRepository.GetByCPFAsync(CPF);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            var clienteEntity = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clienteEntity = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task Remove(int id)
        {
            var clienteEntity = _clienteRepository.GetByIdAsync(id).Result;
            await _clienteRepository.RemoveAsync(clienteEntity);
        }

        public async Task Update(ClienteDTO clienteDto)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.UpdateAsync(clienteEntity);
        }
        public async Task<bool> ExistsCPF(string CPF)
        {
            if (CPF.IsCPF())
            {
                CPF = CPF.FormatOnlyNumericCPF();
            }

            var clienteEntity = await _clienteRepository.GetByCPFAsync(CPF);
            return clienteEntity is null ? false : true;
        }
    }
}
