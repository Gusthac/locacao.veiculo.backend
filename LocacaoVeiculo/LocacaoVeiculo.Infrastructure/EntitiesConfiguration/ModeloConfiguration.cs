using LocacaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoVeiculo.Infrastructure.EntitiesConfiguration
{
    class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.NomeModelo).HasMaxLength(50).IsRequired();
        }
    }
}
