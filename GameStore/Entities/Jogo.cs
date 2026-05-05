namespace GameStore.Entities;

public class Jogo : EntityBase
{
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public DateTime DataLancamento { get; set; }
}

