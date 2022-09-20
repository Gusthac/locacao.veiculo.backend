using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class OperadorDTO
    {
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Informe o nome do operador")]
        [MinLength(1)]
        [MaxLength(200)]
        public string Nome { get; set; }
    }
}
