using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.ViewModels;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using Projeto.Presentation.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Projeto.Presentation.Controllers
{
    [Authorize("Bearer")]
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        //atributo
        private readonly IClienteRepository repository;

        //construtor para injeção de dependência
        public ClienteController(IClienteRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteCadastroViewModel model)
        {
            if(!ModelState.IsValid) //se ocorreram erros de validação..
            {
                //Erro 400 BAD REQUEST
                return BadRequest(ValidationUtil.GetErrors(ModelState)); 
            }

            try
            {
                var cliente = Mapper.Map<Cliente>(model);
                repository.Create(cliente);

                return Ok($"Cliente '{model.Nome}' cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClienteEdicaoViewModel model)
        {
            if (!ModelState.IsValid) //se ocorreram erros de validação..
            {
                return BadRequest(ValidationUtil.GetErrors(ModelState));
            }

            try
            {
                var cliente = Mapper.Map<Cliente>(model);
                repository.Update(cliente);

                return Ok($"Cliente '{model.Nome}' atualizado com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(int idCliente)
        {            
            try
            {
                var cliente = repository.SelectById(idCliente);
                repository.Remove(cliente);

                return Ok($"Cliente '{cliente.Nome}' excluído com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = Mapper.Map<List<ClienteConsultaViewModel>>
                            (repository.SelectAll());

                return Ok(lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(int idCliente)
        {
            try
            {
                var model = Mapper.Map<ClienteConsultaViewModel>
                            (repository.SelectById(idCliente));

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}