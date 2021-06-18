using Microsoft.AspNetCore.Mvc;
using NycBank.Domain.Commands;
using NycBank.Domain.Entities;
using NycBank.Domain.Handlers;
using NycBank.Domain.Repository;
using System;
using System.Collections.Generic;

namespace NycBank.Api.Controllers
{
    public class CategoriaController : Controller
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Categoria> GetAll(
                   [FromServices] ICategoriaRepository repository)
        {
            return repository.GetList();
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CreateProduto(
        [FromBody] CreateCategoriaCommand command,
        [FromServices] CategoriaHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("{nome:alpha}")]
        [HttpGet]
        public IActionResult GetName(string nome,
        [FromServices] ICategoriaRepository repository)
        {
            var nomeProduto = repository.GetName(nome);
            return Ok(nomeProduto);

        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult UpdateProduto(
        [FromBody] UpdateCategoriaCommand command,
        [FromServices] CategoriaHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        public IActionResult DelProduto(Guid id,
        [FromServices] IProdutoRepository repository)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}
