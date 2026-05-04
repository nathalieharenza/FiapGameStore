namespace GameStore.Entity;

public class Jogo
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataLancamento { get; set; }
    public required string Editora { get; set; }
}