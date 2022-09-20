using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class OperadorService : IOperadorService
    {
        private readonly IOperadorRepository _operadorRepository;
        private readonly IMapper _mapper;
        public OperadorService(IOperadorRepository operadorRepository,
            IMapper mapper)
        {
            _operadorRepository = operadorRepository;
            _mapper = mapper;
        }
        public async Task<OperadorDTO> Add(OperadorDTO operadorDto)
        {
            var operadorEntity = _mapper.Map<Operador>(operadorDto);
            var operador = await _operadorRepository.CreateAsync(operadorEntity);
            return _mapper.Map<OperadorDTO>(operador);
        }

        public async Task<OperadorDTO> GetByMatricula(string matricula)
        {
            var operadorEntity = await _operadorRepository.GetByMatriculaAsync(matricula);
            return _mapper.Map<OperadorDTO>(operadorEntity);
        }

        public async Task<IEnumerable<OperadorDTO>> GetOperadores()
        {
            var operadorEntity = await _operadorRepository.GetOperadoresAsync();
            return _mapper.Map<IEnumerable<OperadorDTO>>(operadorEntity);
        }

        public async Task Remove(string matricula)
        {
            var operadorEntity = _operadorRepository.GetByMatriculaAsync(matricula).Result;
            await _operadorRepository.RemoveAsync(operadorEntity);
        }

        public async Task Update(OperadorDTO operadorDto)
        {
            var operadorEntity = _mapper.Map<Operador>(operadorDto);
            await _operadorRepository.UpdateAsync(operadorEntity);
        }
    }
}
