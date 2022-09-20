namespace LocacaoVeiculo.Domain.Entities
{
    public class Usuario
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Operador Operador { get; set; }
    }
}
