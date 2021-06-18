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
        [Route("categoria")]
        [HttpGet]
        public IEnumerable<Categoria> GetAllCategoria(
                   [FromServices] ICategoriaRepository repository)
        {
            return repository.GetList();
        }

        [Route("categoria")]
        [HttpPost]
        public GenericCommandResult CreateCategoria(
        [FromBody] CreateCategoriaCommand command,
        [FromServices] CategoriaHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("categoria/{nome:alpha}")]
        [HttpGet]
        public IActionResult GetCategoria(string nome,
        [FromServices] ICategoriaRepository repository)
        {
            var nomeProduto = repository.GetName(nome);
            return Ok(nomeProduto);

        }

        [Route("categoria")]
        [HttpPut]
        public GenericCommandResult UpdateCategoria(
        [FromBody] UpdateCategoriaCommand command,
        [FromServices] CategoriaHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("categoria/{id:guid}")]
        [HttpDelete]
        public IActionResult DelCategoria(Guid id,
        [FromServices] ICategoriaRepository repository)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}
