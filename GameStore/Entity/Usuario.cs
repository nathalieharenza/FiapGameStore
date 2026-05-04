namespace GameStore.Entity;

public class Usuario
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public DateTime DataCricao { get; set; }
}