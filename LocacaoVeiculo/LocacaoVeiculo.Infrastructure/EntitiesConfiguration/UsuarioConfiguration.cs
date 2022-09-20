using LocacaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoVeiculo.Infrastructure.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.UserName);
            builder.Property(p => p.UserName).HasMaxLength(30);
            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.Cliente).WithOne(p => p.Usuario).HasForeignKey<Cliente>(p => p.CPF);
            builder.HasOne(p => p.Operador).WithOne(p => p.Usuario).HasForeignKey<Operador>(p => p.Matricula);
        }
    }
}
