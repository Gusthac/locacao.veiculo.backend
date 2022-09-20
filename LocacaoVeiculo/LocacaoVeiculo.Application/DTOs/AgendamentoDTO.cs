using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class AgendamentoDTO
    {
        [Required(ErrorMessage = "Informe a categoria")]
        [EnumDataType(typeof(CategoriaVeiculoEnum), ErrorMessage = "Categoria do veiculo valida deve estar em letras minusculas")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de horas para locacao")]
        [Range(1, 3000, ErrorMessage = "A quantidade de horas deve ser entre 1 e 3000")]
        public int TotalHorasLocacao { get; set; }

        public decimal ValorLocacao { get; set; }

        public int Id_Veiculo { get; set; }
    }
}
