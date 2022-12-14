using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Repository.Contracts;
using Projeto.Presentation.ViewModels;
using Projeto.Presentation.Utils;
using AutoMapper;
using Projeto.Entities;

namespace Projeto.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        //atributo
        private readonly IUsuarioRepository repository;

        //construtor para injeção de dependência
        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioCadastroViewModel model)
        {
            if (!ModelState.IsValid) //se ocorreram erros de validação..
            {
                //Erro 400 BAD REQUEST
                return BadRequest(ValidationUtil.GetErrors(ModelState));
            }

            try
            {
                if(repository.HasUsername(model.Username))
                {
                    return BadRequest($"O username {model.Username} já está cadastrado.");
                }

                var usuario = Mapper.Map<Usuario>(model);
                repository.Create(usuario);

                return Ok($"Usuário {usuario.Nome}, cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }
    }
}