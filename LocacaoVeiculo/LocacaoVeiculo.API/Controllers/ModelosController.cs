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
    public class ModelosController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        public ModelosController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<IEnumerable<ModeloDTO>>> Get()
        {
            var modelos = await _modeloService.GetModelos();
            return Ok(modelos);
        }

        [HttpGet("{id}", Name = "GetModelo")]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<ModeloDTO>> Get(int id)
        {
            var modelo = await _modeloService.GetById(id);

            if (modelo == null)
            {
                return NotFound();
            }
            return Ok(modelo);
        }

        [HttpPost]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult> Post([FromBody] ModeloDTO modeloDto)
        {
            var modelo = await _modeloService.Add(modeloDto);

            return new CreatedAtRouteResult("GetModelo",
                new { id = modelo.Id }, modelo);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult> Put(int id, [FromBody] ModeloDTO modeloDto)
        {
            if (id != modeloDto.Id)
            {
                return BadRequest();
            }
            await _modeloService.Update(modeloDto);
            return Ok(modeloDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Operador")]
        public async Task<ActionResult<ModeloDTO>> Delete(int id)
        {
            var modeloDto = await _modeloService.GetById(id);
            if (modeloDto == null)
            {
                return NotFound();
            }
            await _modeloService.Remove(id);
            return Ok(modeloDto);
        }
    }
}
