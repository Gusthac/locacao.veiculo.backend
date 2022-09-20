using LocacaoVeiculo.Application.DTOs;
using LocacaoVeiculo.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LocacaoVeiculo.Domain.Extension;
using LocacaoVeiculo.Domain.Enums;

namespace LocacaoVeiculo.Application.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDTO GenerateToken(UsuarioDTO usuario)
        {
            var secret = _configuration["Jwt:Key"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            var role = usuario.UserName.IsCPF() ? UsuarioRoleEnum.Cliente.ToString() : UsuarioRoleEnum.Operador.ToString();

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName),
                 new Claim(ClaimTypes.Role, role)
             };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credenciais);

            return new TokenDTO()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token JWT OK"
            };
        }
    }
}