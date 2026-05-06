namespace GameStore.Controllers;

using GameStore.Models;
using GameStore.Repositories;
using GameStore.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsersController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

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
        
        var user = new Usuario()
        {
            Id = Guid.NewGuid(),
            Nome = customer.Nome,
            Email = customer.Email,
            Senha = customer.Senha
        };
        _usuarioRepository.Cadastrar(user);
        return Ok();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult<Customer> ConsultarUsuario([FromRoute] Guid id)
    {
        var user = _usuarioRepository.ObterPorId(id);
    
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
        return Ok(_usuarioRepository.ObterTodos());
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult<Customer> AtualizarUsuario([FromRoute] Guid id, [FromBody] Customer usuarioAtualizado)
    {
        var user = _usuarioRepository.ObterPorId(id);

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

        _usuarioRepository.Alterar(user);

        return Ok(new { mensagem = "Usuário atualizado com sucesso", user });
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize ("admin")]
    public ActionResult DeletarUsuario([FromRoute] Guid id)
    {
        var user = _usuarioRepository.ObterPorId(id);
    
        if (user == null)
        {
            return NotFound(new { mensagem = $"Usuário com ID {id} não encontrado" });
        }
    
        _usuarioRepository.Deletar(id);
        return Ok(new { mensagem = "Usuário deletado com sucesso" });
    }
    
    
}

