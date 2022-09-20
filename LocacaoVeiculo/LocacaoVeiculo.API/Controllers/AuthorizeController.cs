using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LocacaoVeiculo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;
        public AuthorizeController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize(Roles = "Operador, Cliente")]
        public async Task<ActionResult<dynamic>> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var usuario = await _usuarioService.GetUsuario(identity.Name);

            return Ok(usuario);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = await _usuarioService.CreateUsuario(usuarioDTO);

            if (usuario == null)
            {
                return BadRequest("ERRO");
            }
            else
            {
                return Ok(_tokenService.GenerateToken(usuario));
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var usuario = await _usuarioService.ValidateCredentials(usuarioDTO);

            if (usuario == null)
            {
                ModelState.AddModelError("message", "Usuário ou senha inválidos");
                return BadRequest(ModelState);
            }
            else 
            {
                return Ok(_tokenService.GenerateToken(usuario));
            }
        }
    }
}
