namespace GameStore.Entities;

public class Usuario : EntityBase
{
    public required string Email { get; set; } = string.Empty;
    public required string Senha { get; set; } = string.Empty;
}

