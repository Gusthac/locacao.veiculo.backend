using LocacaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoVeiculo.Infrastructure.EntitiesConfiguration
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id_Marca).IsRequired();
            builder.Property(p => p.Id_Modelo).IsRequired();
            builder.Property(p => p.Placa).HasMaxLength(12).IsRequired();
            builder.Property(p => p.Ano).IsRequired();
            builder.Property(p => p.ValorHora).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Combustivel).HasMaxLength(15).IsRequired();
            builder.Property(p => p.LimitePortaMalas).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Categoria).HasMaxLength(10).IsRequired();

            builder.HasOne(p => p.Marca).WithMany().HasForeignKey(p => p.Id_Marca);
            builder.HasOne(p => p.Modelo).WithMany().HasForeignKey(p => p.Id_Modelo);
        }
    }
}
