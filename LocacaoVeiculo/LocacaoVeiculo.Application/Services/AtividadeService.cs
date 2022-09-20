using AutoMapper;
using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using LocacaoVeiculo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Services
{
    public class AtividadeService : IAtividadeService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public AtividadeService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<SimulacaoLocacaoDTO> CalculateLocacao(SimulacaoLocacaoDTO locacaoDTO)
        {
            int Id_Veiculo = (int)locacaoDTO.Id_Veiculo;

            var veiculoEntity = await _veiculoRepository.GetByIdAsync(Id_Veiculo);
            if (veiculoEntity == null)
            {
                return null;
            }

            locacaoDTO.ValorLocacao = locacaoDTO.TotalHorasLocacao * veiculoEntity.ValorHora;
            return (locacaoDTO);
        }

        public async Task<IEnumerable<AgendamentoDTO>> CalculateSchedule(AgendamentoDTO agendamentoDTO)
        {
            var veiculosEntity = await _veiculoRepository.GetByCategoriaAsync(agendamentoDTO.Categoria);
            if (veiculosEntity == null)
            {
                return null;
            }

            List<AgendamentoDTO> lista = new List<AgendamentoDTO>();
            foreach (var veiculo in veiculosEntity)
            {
                lista.Add(new AgendamentoDTO
                {
                    Id_Veiculo = veiculo.Id,
                    Categoria = agendamentoDTO.Categoria,
                    TotalHorasLocacao = agendamentoDTO.TotalHorasLocacao,
                    ValorLocacao = veiculo.ValorHora * agendamentoDTO.TotalHorasLocacao
                });
            }

            return lista;
        }

        public async Task<CheckListDTO> CalculateCheckList(CheckListDTO checkListDTO)
        {
            int Id_Veiculo = (int)checkListDTO.Id_Veiculo;

            var veiculoEntity = await _veiculoRepository.GetByIdAsync(Id_Veiculo);
            if (veiculoEntity == null)
            {
                return null;
            }

            var valorLocacao = checkListDTO.TotalHorasLocacao * veiculoEntity.ValorHora;
            checkListDTO.ValorFinal = valorLocacao;

            checkListDTO.ValorFinal += (bool)checkListDTO.CarroLimpo ? 0 : (valorLocacao/100 * 30);
            checkListDTO.ValorFinal += (bool)checkListDTO.TanqueCheio ? 0 : (valorLocacao / 100 * 30);
            checkListDTO.ValorFinal += (bool)checkListDTO.Amassados ? (valorLocacao / 100 * 30) : 0;
            checkListDTO.ValorFinal += (bool)checkListDTO.Arranhao ? (valorLocacao / 100 * 30) : 0;

            return (checkListDTO);
        }
    }
}
