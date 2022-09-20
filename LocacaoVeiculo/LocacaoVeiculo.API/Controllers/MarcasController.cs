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
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<IEnumerable<MarcaDTO>>> Get()
        {
            var marcas = await _marcaService.GetMarcas();
            return Ok(marcas);
        }

        [HttpGet("{id}", Name = "GetMarca")]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<MarcaDTO>> Get(int id)
        {
            var marca = await _marcaService.GetById(id);

            if (marca == null)
            {
                return NotFound();
            }
            return Ok(marca);
        }

        [HttpPost]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult> Post([FromBody] MarcaDTO marcaDto)
        {
            var marca = await _marcaService.Add(marcaDto);

            return new CreatedAtRouteResult("GetMarca",
                new { id = marca.Id }, marca);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult> Put(int id, [FromBody] MarcaDTO marcaDto)
        {
            if (id != marcaDto.Id)
            {
                return BadRequest();
            }
            await _marcaService.Update(marcaDto);
            return Ok(marcaDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult<MarcaDTO>> Delete(int id)
        {
            var marcaDto = await _marcaService.GetById(id);
            if (marcaDto == null)
            {
                return NotFound();
            }
            await _marcaService.Remove(id);
            return Ok(marcaDto);
        }
    }
}
