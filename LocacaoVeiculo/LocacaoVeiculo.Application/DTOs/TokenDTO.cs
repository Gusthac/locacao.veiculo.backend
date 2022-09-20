﻿using System;

namespace LocacaoVeiculo.Application.DTOs
{
    public class TokenDTO
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}