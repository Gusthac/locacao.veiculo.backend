using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente")]
        [MinLength(1)]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF do cliente sem pontuacao")]
        [MinLength(1)]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento do cliente")]
        public DateTime Aniversario { get; set; }

        [Required(ErrorMessage = "Informe CEP do cliente sem pontuacao")]
        [MaxLength(8)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Informe o logradouro do cliente")]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o numero de endereco do cliente")]
        [MaxLength(15)]
        public string Numero { get; set; }

        [MaxLength(40)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe a cidade do cliente")]
        [MaxLength(60)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado do cliente")]
        [MaxLength(2)]
        public string Estado { get; set; }
    }
}