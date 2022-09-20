using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;
        public ModeloService(IModeloRepository modeloRepository,
            IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }
        public async Task<ModeloDTO> Add(ModeloDTO modeloDto)
        {
            var modeloEntity = _mapper.Map<Modelo>(modeloDto);
            var modelo = await _modeloRepository.CreateAsync(modeloEntity);
            return _mapper.Map<ModeloDTO>(modelo);
        }

        public async Task<ModeloDTO> GetById(int id)
        {
            var modeloEntity = await _modeloRepository.GetByIdAsync(id);
            return _mapper.Map<ModeloDTO>(modeloEntity);
        }

        public async Task<IEnumerable<ModeloDTO>> GetModelos()
        {
            var modeloEntity = await _modeloRepository.GetModelosAsync();
            return _mapper.Map<IEnumerable<ModeloDTO>>(modeloEntity);
        }

        public async Task Remove(int id)
        {
            var modeloEntity = _modeloRepository.GetByIdAsync(id).Result;
            await _modeloRepository.RemoveAsync(modeloEntity);
        }

        public async Task Update(ModeloDTO modeloDto)
        {
            var modeloEntity = _mapper.Map<Modelo>(modeloDto);
            await _modeloRepository.UpdateAsync(modeloEntity);
        }
    }
}
