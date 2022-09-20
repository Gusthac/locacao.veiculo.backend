using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace LocacaoVeiculo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Operador, Cliente")]
    public class AtividadesController : ControllerBase
    {
        private readonly IAtividadeService _atividadeService;
        public AtividadesController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        [HttpPost]
        [Route("simulacaolocacao")]
        public async Task<ActionResult> LocacaoSimulator([FromBody] SimulacaoLocacaoDTO locacaoDTO)
        {
            var simulacao = await _atividadeService.CalculateLocacao(locacaoDTO);

            if (simulacao == null)
            {
                return NotFound("Veiculo não localizado");
            }
            else
            {
                return Ok(simulacao);
            }
        }

        [HttpPost]
        [Route("agendamento")]
        public async Task<ActionResult> Schedule([FromBody] AgendamentoDTO agendamentoDTO)
        {
            var simulacao = await _atividadeService.CalculateSchedule(agendamentoDTO);

            if (simulacao == null)
            {
                return NotFound("Veiculo não localizado");
            }
            else
            {
                return Ok(simulacao);
            }
        }

        [HttpPost]
        [Route("ckecklist")]
        public async Task<ActionResult> CheckList([FromBody] CheckListDTO checkListDTO)
        {
            var calculo = await _atividadeService.CalculateCheckList(checkListDTO);

            if (calculo == null)
            {
                return NotFound("Veiculo não localizado");
            }
            else
            {
                return Ok(calculo);
            }
        }

        [HttpGet]
        [Route("modelocontrato")]
        public IActionResult ModeloContratoPDF()
        {
            var path = "ModeloContrato/contrato_lorem-ipsum.pdf";
            byte[] pdfBytes = System.IO.File.ReadAllBytes(path);
            MemoryStream ms = new MemoryStream(pdfBytes);
            return new FileStreamResult(ms, "application/pdf");
        }

    }
}
