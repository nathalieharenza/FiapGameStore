using GameStore.Models;

namespace GameStore.Tests.Models;

public class CustomerTests
{
    [Fact]
    public void Construtor_Padrao_DeveGerarIdUnico()
    {
        var c1 = new Customer();
        var c2 = new Customer();

        Assert.NotEqual(Guid.Empty, c1.Id);
        Assert.NotEqual(c1.Id, c2.Id);
    }

    [Fact]
    public void Construtor_ComParametros_DevePreencherPropriedades()
    {
        var customer = new Customer("João", "joao@email.com", "Senha@123");

        Assert.Equal("João", customer.Nome);
        Assert.Equal("joao@email.com", customer.Email);
        Assert.Equal("Senha@123", customer.Senha);
        Assert.NotEqual(Guid.Empty, customer.Id);
    }

    [Theory]
    [InlineData("usuario@email.com")]
    [InlineData("usuario@empresa.com.br")]
    [InlineData("USUARIO@EMAIL.COM")]
    public void ValidarEmail_EmailValido_DeveRetornarTrue(string email)
    {
        var customer = new Customer { Email = email };

        Assert.True(customer.ValidarEmail());
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("semArroba.com")]
    [InlineData("@email.com")]
    [InlineData("usuario@")]
    [InlineData("usuario@email")]
    [InlineData("usuario @email.com")]
    public void ValidarEmail_EmailInvalido_DeveRetornarFalse(string email)
    {
        var customer = new Customer { Email = email };

        Assert.False(customer.ValidarEmail());
    }

    [Theory]
    [InlineData("Senha@123")]
    [InlineData("Abc!1234")]
    [InlineData("P@ssw0rd")]
    public void ValidarSenha_SenhaValida_DeveRetornarTrue(string senha)
    {
        var customer = new Customer { Senha = senha };

        Assert.True(customer.ValidarSenha());
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("curta@1")]        
    [InlineData("semNumero@")]     
    [InlineData("12345678@")]      
    [InlineData("SemEspecial1")]   
    
    public void ValidarSenha_SenhaInvalida_DeveRetornarFalse(string senha)
    {
        var customer = new Customer { Senha = senha };

        Assert.False(customer.ValidarSenha());
    }

    [Fact]
    public void ValidarTodos_DadosValidos_DeveRetornarTrue()
    {
        var customer = new Customer("Maria", "maria@email.com", "Senha@123");

        Assert.True(customer.ValidarTodos());
    }

    [Theory]
    [InlineData("", "maria@email.com", "Senha@123")]      
    [InlineData("   ", "maria@email.com", "Senha@123")]   
    [InlineData("Maria", "emailinvalido", "Senha@123")]   
    [InlineData("Maria", "maria@email.com", "fraca")]     
    public void ValidarTodos_DadosInvalidos_DeveRetornarFalse(string nome, string email, string senha)
    {
        var customer = new Customer(nome, email, senha);

        Assert.False(customer.ValidarTodos());
    }
}
