namespace LocacaoVeiculo.Domain.Entities
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int Id_Marca { get; set; }
        public virtual Marca Marca { get; set; }
        public int Id_Modelo { get; set; }
        public virtual Modelo Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public decimal ValorHora { get; set; }
        public string Combustivel { get; set; }
        public string LimitePortaMalas { get; set; }
        public string Categoria { get; set; }
    }
}
