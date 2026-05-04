namespace GameStore.Controllers;

using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    
    // Simulando um banco de dados em memória para demonstração
    private static readonly List<Customer> Customer = new();
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult<Customer> CadastrarUsuário([FromBody] Customer customer)
    {
        if (customer == null || !customer.ValidarTodos())
        {
            return BadRequest(new { mensagem = "Dados do usuário inválidos" });
        }
    
        Customer.Add(customer);
        return CreatedAtAction(nameof(ConsultarUsuario), new { id = customer.Id }, customer);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult<Customer> ConsultarUsuario(Guid id)
    {
        var user = Customer.FirstOrDefault(g => g.Id == id);
    
        if (user == null)
        {
            return NotFound(new { mensagem = $"Usuário com ID {id} não encontrado" });
        }
    
        return Ok(user);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult<IEnumerable<Customer>> ListarTodosUsuarios()
    {
        return Ok(Customer);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult<Customer> AtualizarUsuario(Guid id, [FromBody] Customer usuarioAtualizado)
    {
        var user = Customer.FirstOrDefault(g => g.Id == id);

        if (user == null)
        {
            return NotFound(new { mensagem = $"Usuário com ID {id} não encontrado" });
        }

        if (usuarioAtualizado == null || !usuarioAtualizado.ValidarTodos())
        {
            return BadRequest(new { mensagem = "Dados do usuário inválidos" });
        }
        
        if (usuarioAtualizado.Email == user.Email &&
            usuarioAtualizado.Nome == user.Nome &&
            usuarioAtualizado.Senha == user.Senha)
        {
            return BadRequest(new { mensagem = "Nenhum dado foi alterado. Informe valores diferentes dos atuais." });
        }

        user.Email = usuarioAtualizado.Email;
        user.Nome = usuarioAtualizado.Nome;
        user.Senha = usuarioAtualizado.Senha;

        return Ok(new { mensagem = "Usuário atualizado com sucesso", user });
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult DeletarUsuario(Guid id)
    {
        var user = Customer.FirstOrDefault(g => g.Id == id);
    
        if (user == null)
        {
            return NotFound(new { mensagem = $"Usuário com ID {id} não encontrado" });
        }
    
        Customer.Remove(user);
        return Ok(new { mensagem = "Jogo deletado com sucesso" });
    }
    
    
}

