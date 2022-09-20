using LocacaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoVeiculo.Infrastructure.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.CPF).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Aniversario).IsRequired();
            builder.Property(p => p.CEP).HasMaxLength(8).IsRequired();
            builder.Property(p => p.Logradouro).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Numero).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Complemento).HasMaxLength(40);
            builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Estado).HasMaxLength(2).IsRequired();
            builder.HasIndex(i => i.CPF);
        }
    }
}
