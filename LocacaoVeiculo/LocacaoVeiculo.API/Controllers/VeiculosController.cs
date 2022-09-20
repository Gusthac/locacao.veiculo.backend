using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get()
        {
            var veiculos = await _veiculoService.GetVeiculos();
            return Ok(veiculos);
        }

        [HttpGet("{id}", Name = "GetVeiculo")]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<VeiculoDTO>> Get(int id)
        {
            var veiculo = await _veiculoService.GetById(id);

            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPost]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult> Post([FromBody] VeiculoDTO veiculoDto)
        {
            var veiculo = await _veiculoService.Add(veiculoDto);

            return new CreatedAtRouteResult("GetVeiculo",
                new { id = veiculo.Id }, veiculo);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult> Put(int id, [FromBody] VeiculoDTO veiculoDto)
        {
            if (id != veiculoDto.Id)
            {
                return BadRequest();
            }
            await _veiculoService.Update(veiculoDto);
            return Ok(veiculoDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult<VeiculoDTO>> Delete(int id)
        {
            var veiculoDto = await _veiculoService.GetById(id);
            if (veiculoDto == null)
            {
                return NotFound();
            }
            await _veiculoService.Remove(id);
            return Ok(veiculoDto);
        }
    }
}
