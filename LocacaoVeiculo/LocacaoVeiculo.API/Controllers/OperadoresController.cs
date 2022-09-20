using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LocacaoVeiculo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Operador")]
    public class OperadoresController : ControllerBase
    {
        private readonly IOperadorService _operadorService;
        public OperadoresController(IOperadorService operadorService)
        {
            _operadorService = operadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperadorDTO>>> Get()
        {
            var operadores = await _operadorService.GetOperadores();
            return Ok(operadores);
        }

        [HttpGet("{matricula}", Name = "GetOperador")]
        public async Task<ActionResult<OperadorDTO>> Get(string matricula)
        {
            var operador = await _operadorService.GetByMatricula(matricula);

            if (operador == null)
            {
                return NotFound();
            }
            return Ok(operador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OperadorDTO operadorDto)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name != operadorDto.Matricula)
            {
                return Forbid();
            }

            var operador = await _operadorService.Add(operadorDto);

            return new CreatedAtRouteResult("GetOperador",
                new { matricula = operador.Matricula }, operador);
        }

        [HttpPut("{matricula}")]
        public async Task<ActionResult> Put(string matricula, [FromBody] OperadorDTO operadorDto)
        {
            if (matricula != operadorDto.Matricula)
            {
                return BadRequest();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name != operadorDto.Matricula)
            {
                return Forbid();
            }

            var operador = await _operadorService.GetByMatricula(operadorDto.Matricula);
            if (operador.Matricula != identity.Name)
            {
                return BadRequest();
            }

            await _operadorService.Update(operadorDto);
            return Ok(operadorDto);
        }

        [HttpDelete("{matricula}")]
        public async Task<ActionResult> Delete(string matricula)
        {
            var operadorDto = await _operadorService.GetByMatricula(matricula);
            if (operadorDto == null)
            {
                return NotFound();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name != operadorDto.Matricula)
            {
                return Forbid();
            }

            await _operadorService.Remove(matricula);
            return Ok(operadorDto);
        }
    }
}
