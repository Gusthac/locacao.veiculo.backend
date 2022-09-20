using LocacaoVeiculo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.Application.Interfaces
{
    public interface IAtividadeService
    {
        Task<SimulacaoLocacaoDTO> CalculateLocacao(SimulacaoLocacaoDTO locacaoDTO);
        Task<IEnumerable<AgendamentoDTO>> CalculateSchedule(AgendamentoDTO agendamentoDTO);
        Task<CheckListDTO> CalculateCheckList(CheckListDTO checkListDTO);
    }
}
