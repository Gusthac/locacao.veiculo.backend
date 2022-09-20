using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class SimulacaoLocacaoDTO
    {
        [Required(ErrorMessage = "Informe o id do veiculo")]
        public int? Id_Veiculo { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de horas para locacao")]
        [Range(1, 3000, ErrorMessage = "A quantidade de horas deve ser entre 1 e 3000")]
        public int TotalHorasLocacao { get; set; }

        public decimal ValorLocacao { get; set; }
    }
}
