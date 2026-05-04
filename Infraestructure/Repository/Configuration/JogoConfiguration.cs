using GameStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Repository.Configuration;

public class JogoConfiguration
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.ToTable("Jogos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(x => x.Descricao).HasColumnType("TEXT").IsRequired();
        builder.Property(x => x.Preco).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(x => x.DataLancamento).HasColumnType("DATETIME").IsRequired();
        builder.Property(x => x.Editora).HasColumnType("VARCHAR(100)").IsRequired();
    }
}