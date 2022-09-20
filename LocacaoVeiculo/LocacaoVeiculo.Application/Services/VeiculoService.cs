using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Entities;
using LocacaoVeiculo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;
        public VeiculoService(IVeiculoRepository veiculoRepository,
            IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }
        public async Task<VeiculoDTO> Add(VeiculoDTO veiculoDto)
        {
            var veiculoEntity = _mapper.Map<Veiculo>(veiculoDto);
            var veiculo = await _veiculoRepository.CreateAsync(veiculoEntity);
            return _mapper.Map<VeiculoDTO>(veiculo);
        }

        public async Task<VeiculoDTO> GetById(int id)
        {
            var veiculoEntity = await _veiculoRepository.GetByIdAsync(id);
            return _mapper.Map<VeiculoDTO>(veiculoEntity);
        }

        public async Task<IEnumerable<VeiculoDTO>> GetVeiculos()
        {
            var veiculoEntity = await _veiculoRepository.GetVeiculosAsync();
            return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculoEntity);
        }

        public async Task Remove(int id)
        {
            var veiculoEntity = _veiculoRepository.GetByIdAsync(id).Result;
            await _veiculoRepository.RemoveAsync(veiculoEntity);
        }

        public async Task Update(VeiculoDTO veiculoDto)
        {
            var veiculoEntity = _mapper.Map<Veiculo>(veiculoDto);
            await _veiculoRepository.UpdateAsync(veiculoEntity);
        }
    }
}
