using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class ModeloDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do modelo")]
        [MinLength(1)]
        [MaxLength(50)]
        public string NomeModelo { get; set; }
    }
}
