using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;
        public MarcaService(IMarcaRepository marcaRepository,
            IMapper mapper)
        {
            _marcaRepository = marcaRepository;
            _mapper = mapper;
        }
        public async Task<MarcaDTO> Add(MarcaDTO marcaDto)
        {
            var marcaEntity = _mapper.Map<Marca>(marcaDto);
            var marca = await _marcaRepository.CreateAsync(marcaEntity);
            return _mapper.Map<MarcaDTO>(marca);
        }

        public async Task<MarcaDTO> GetById(int id)
        {
            var marcaEntity = await _marcaRepository.GetByIdAsync(id);
            return _mapper.Map<MarcaDTO>(marcaEntity);
        }

        public async Task<IEnumerable<MarcaDTO>> GetMarcas()
        {
            var marcaEntity = await _marcaRepository.GetMarcasAsync();
            return _mapper.Map<IEnumerable<MarcaDTO>>(marcaEntity);
        }

        public async Task Remove(int id)
        {
            var marcaEntity = _marcaRepository.GetByIdAsync(id).Result;
            await _marcaRepository.RemoveAsync(marcaEntity);
        }

        public async Task Update(MarcaDTO marcaDto)
        {
            var marcaEntity = _mapper.Map<Marca>(marcaDto);
            await _marcaRepository.UpdateAsync(marcaEntity);
        }
    }
}
