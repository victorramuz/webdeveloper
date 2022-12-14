using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.ViewModels;
using Projeto.Presentation.Utils;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Projeto.Repository.Contracts;

namespace Projeto.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        //atributo
        private readonly IUsuarioRepository repository;

        //construtor para injeção de dependência
        public LoginController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public object Post([FromBody] LoginViewModel model, 
                           [FromServices] TokenConfiguration tokenConfiguration,
                           [FromServices] LoginConfiguration loginConfiguration)
        {
            //verificar se a model passou nas regras de validação
            if(ModelState.IsValid)
            {
                try
                {
                    var usuario = repository.Find(model.Username,
                        MD5Configuration.Encrypt(model.Password));

                    if(usuario != null)
                    {
                        //criando as credenciais do usuario..
                        ClaimsIdentity identity = new ClaimsIdentity(
                                new GenericIdentity(model.Username, "Login"),
                                new[]
                                {
                                //registrando que o email representa o USERNAME do usuario..
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                new Claim(JwtRegisteredClaimNames.UniqueName, model.Username)
                                }
                            );

                        //gerando o token
                        var dataCriacao = DateTime.Now;
                        var dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                        var handler = new JwtSecurityTokenHandler();
                        var securityToken = handler.CreateToken(new
                        SecurityTokenDescriptor
                        {
                            Issuer = tokenConfiguration.Issuer,
                            Audience = tokenConfiguration.Audience,
                            SigningCredentials = loginConfiguration.SigningCredentials,
                            Subject = identity,
                            NotBefore = dataCriacao,
                            Expires = dataExpiracao
                        });

                        var token = handler.WriteToken(securityToken); //CRIADO!!

                        return new
                        {
                            authenticated = true,
                            created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                            expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                            accessToken = token,
                            message = "OK"
                        };
                    }
                    else
                    {
                        return BadRequest("Acesso Negado. Usuário inválido.");
                    }
                }
                catch(Exception e)
                {
                    //retornar STATUS 500 Internal Server Error
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                //retornar STATUS 400 BadRequest
                return BadRequest(ValidationUtil.GetErrors(ModelState));
            }
        }
    }
}