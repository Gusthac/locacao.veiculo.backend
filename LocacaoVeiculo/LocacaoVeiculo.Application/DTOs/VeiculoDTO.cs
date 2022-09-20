using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculo.Application.DTOs
{
    public class VeiculoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o id da marca")]
        public int? Id_Marca { get; set; }

        [Required(ErrorMessage = "Informe o id do modelo")]
        public int? Id_Modelo { get; set; }

        [Required(ErrorMessage = "Informe a placa")]
        [MinLength(7)]
        [MaxLength(12)]
        public string Placa { get; set; }

        [Range(1900, 2100)]
        [Required(ErrorMessage = "Informe o ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Informe o valor hora")]
        public decimal ValorHora { get; set; }

        [Required(ErrorMessage = "Informe o combustivel")]
        [EnumDataType(typeof(CombustivelEnum), ErrorMessage = "Combustivel valido deve estar em letras minusculas")]
        public string Combustivel { get; set; }

        [Required(ErrorMessage = "Informe o limite de porta malas")]
        public string LimitePortaMalas { get; set; }

        [Required(ErrorMessage = "Informe a categoria")]
        [EnumDataType(typeof(CategoriaVeiculoEnum), ErrorMessage = "Categoria do veiculo valida deve estar em letras minusculas")]
        public string Categoria { get; set; }
    }
}
