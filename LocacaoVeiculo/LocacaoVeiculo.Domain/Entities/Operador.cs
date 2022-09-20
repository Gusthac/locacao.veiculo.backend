namespace LocacaoVeiculo.Domain.Entities
{
    public class Operador
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
