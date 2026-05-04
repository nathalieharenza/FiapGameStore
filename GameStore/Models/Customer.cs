namespace GameStore.Models;

using System.Text.RegularExpressions;

public class Customer
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;

    public Customer()
    {
        Id = Guid.NewGuid();
    }

    public Customer(string nome, string email, string senha) : this()
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }
    
    public bool ValidarEmail()
    {
        if (string.IsNullOrWhiteSpace(Email))
            return false;

        try
        {
            var regex = new Regex(@"^[^\s@]+@[a-zA-Z0-9-]+\.com(\.[a-zA-Z]{2,})?$", RegexOptions.IgnoreCase);
            return regex.IsMatch(Email);
        }
        catch
        {
            return false;
        }
    }
    
    public bool ValidarSenha()
    {
        if (string.IsNullOrWhiteSpace(Senha))
            return false;
        
        if (Senha.Length < 8)
            return false;
        
        if (!Regex.IsMatch(Senha, @"[a-zA-Z]"))
            return false;

        if (!Regex.IsMatch(Senha, @"[0-9]"))
            return false;

        if (!Regex.IsMatch(Senha, @"[!@#$%^&*()_+\-=\[\]{};':"",.<>?/\\|`~]"))
            return false;

        return true;
    }
    
    public bool ValidarTodos()
    {
        return !string.IsNullOrWhiteSpace(Nome) && ValidarEmail() && ValidarSenha();
    }
}

