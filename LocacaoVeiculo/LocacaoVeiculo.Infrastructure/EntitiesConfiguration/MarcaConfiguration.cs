using LocacaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoVeiculo.Infrastructure.EntitiesConfiguration
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.NomeMarca).HasMaxLength(30).IsRequired();
        }
    }
}
