using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class MarcaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da marca")]
        [MinLength(1)]
        [MaxLength(30)]
        public string NomeMarca { get; set; }
    }
}
