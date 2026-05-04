using Microsoft.AspNetCore.Authorization;

namespace GameStore.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<object> Login([FromBody] LoginRequest credenciais)
    {
        if (string.IsNullOrEmpty(credenciais.Usuario) || string.IsNullOrEmpty(credenciais.Senha))
        {
            return Unauthorized(new { mensagem = "Email ou senha inválidos" });
        }
        
        if (credenciais.Usuario == "admin" && credenciais.Senha == "admin")
        {
            var token = GerarToken(credenciais.Usuario, "admin");
            return Ok(new { token, mensagem = "Login realizado com sucesso" });
        }
        
        if (credenciais.Usuario == "user" && credenciais.Senha == "User@123")
        {
            var token = GerarToken(credenciais.Usuario, "User");
            return Ok(new { token, mensagem = "Login realizado com sucesso" });
        }

        return Unauthorized(new { mensagem = "Credenciais inválidas" });
    }
    
    private string GerarToken(string username, string role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: "GameStore",
            audience: "GameStoreAPI",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credenciais
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}