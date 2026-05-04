using GameStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Repository.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Senha).IsRequired();
        builder.Property(x => x.DataCricao).HasColumnType("DATETIME").IsRequired();
    }
}