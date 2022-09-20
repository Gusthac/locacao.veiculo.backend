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
    [Authorize(Roles = "Cliente")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _clienteService.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await _clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet]
        [Route("CPF/{CPF}")]
        public async Task<ActionResult<ClienteDTO>> GetByCPF(string CPF)
        {
            var cliente = await _clienteService.GetByCPF(CPF);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name != clienteDto.CPF)
            {
                return Forbid();
            }

            var cliente = await _clienteService.Add(clienteDto);

            return new CreatedAtRouteResult("GetCliente",
                new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.Id)
            {
                return BadRequest();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name != clienteDto.CPF)
            {
                return Forbid();
            }

            await _clienteService.Update(clienteDto);
            return Ok(clienteDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var clienteDto = await _clienteService.GetById(id);
            if (clienteDto == null)
            {
                return NotFound();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.Name != clienteDto.CPF)
            {
                return Forbid();
            }

            await _clienteService.Remove(id);
            return Ok(clienteDto);
        }
    }
}
