using GameStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Configuration;

public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.HasKey(j => j.Id);
        
        builder.Property(j => j.Nome)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(j => j.Descricao)
            .HasMaxLength(1000);
        
        builder.Property(j => j.Preco)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(j => j.DataLancamento)
            .HasColumnType("datetime2");
        
        builder.Property(j => j.DataCriacao)
            .HasColumnType("datetime2");
    }
}

