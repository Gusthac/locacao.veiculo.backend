using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class CheckListDTO
    {
        [Required(ErrorMessage = "Informe o id do veiculo")]
        public int? Id_Veiculo { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de horas para locacao")]
        [Range(1, 3000, ErrorMessage = "A quantidade de horas deve ser entre 1 e 3000")]
        public int TotalHorasLocacao { get; set; }

        [Required(ErrorMessage = "Informe se carro limpo ou nao")]
        public bool? CarroLimpo { get; set; }

        [Required(ErrorMessage = "Informe se tanque cheio ou nao")]
        public bool? TanqueCheio { get; set; }

        [Required(ErrorMessage = "Informe se carro amassado ou nao")]
        public bool? Amassados { get; set; }

        [Required(ErrorMessage = "Informe se carro arranhado ou nao")]
        public bool? Arranhao { get; set; }

        public decimal ValorFinal { get; set; }
    }
}
