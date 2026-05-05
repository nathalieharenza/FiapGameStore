using FluentAssertions;
using GameStore.Models;
using TechTalk.SpecFlow;

namespace GameStore.Specs.StepDefinitions;

[Binding]
public class CustomerStepDefinitions
{
    private Customer _customer = new();
    private bool _resultado;

    [Given(@"que dois clientes são criados com o construtor padrão")]
    public void DadoQueDoisClientesSaoCriadosComOConstrutorPadrao()
    {
        _customer = new Customer();
    }

    [Then(@"os Ids devem ser diferentes e não vazios")]
    public void EntaoOsIdsDevemSerDiferentesENaoVazios()
    {
        var outro = new Customer();
        _customer.Id.Should().NotBe(Guid.Empty);
        outro.Id.Should().NotBe(Guid.Empty);
        _customer.Id.Should().NotBe(outro.Id);
    }

    [Given(@"que um cliente é criado com nome ""(.*)"", email ""(.*)"" e senha ""(.*)""")]
    public void DadoQueUmClienteECriadoComNomeEmailESenha(string nome, string email, string senha)
    {
        _customer = new Customer(nome, email, senha);
    }

    [Then(@"o cliente deve ter nome ""(.*)"", email ""(.*)"" e senha ""(.*)""")]
    public void EntaoOClienteDeveTerNomeEmailESenha(string nome, string email, string senha)
    {
        _customer.Nome.Should().Be(nome);
        _customer.Email.Should().Be(email);
        _customer.Senha.Should().Be(senha);
        _customer.Id.Should().NotBe(Guid.Empty);
    }

    [Given(@"que um cliente possui o email ""(.*)""")]
    public void DadoQueUmClientePossuiOEmail(string email)
    {
        _customer = new Customer { Email = email };
    }

    [When(@"o email for validado")]
    public void QuandoOEmailForValidado()
    {
        _resultado = _customer.ValidarEmail();
    }

    [Given(@"que um cliente possui a senha ""(.*)""")]
    public void DadoQueUmClientePossuiASenha(string senha)
    {
        _customer = new Customer { Senha = senha };
    }

    [When(@"a senha for validada")]
    public void QuandoASenhaForValidada()
    {
        _resultado = _customer.ValidarSenha();
    }

    [When(@"todos os dados forem validados")]
    public void QuandoTodosOsDadosForemValidados()
    {
        _resultado = _customer.ValidarTodos();
    }

    [Then(@"o resultado deve ser verdadeiro")]
    public void EntaoOResultadoDeveSerVerdadeiro()
    {
        _resultado.Should().BeTrue();
    }

    [Then(@"o resultado deve ser falso")]
    public void EntaoOResultadoDeveSerFalso()
    {
        _resultado.Should().BeFalse();
    }
}
