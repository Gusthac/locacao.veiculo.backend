using LocacaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoVeiculo.Infrastructure.EntitiesConfiguration
{
    public class OperadorConfiguration : IEntityTypeConfiguration<Operador>
    {
        public void Configure(EntityTypeBuilder<Operador> builder)
        {
            builder.HasKey(t => t.Matricula);
            builder.Property(p => p.Matricula).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.HasIndex(i => i.Matricula);
        }
    }
}