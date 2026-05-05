namespace GameStore.Entities;

public class EntityBase
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public DateTime DataCriacao{ get; set; }
}

