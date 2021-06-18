using Microsoft.AspNetCore.Mvc;
using NycBank.Domain.Commands;
using NycBank.Domain.Entities;
using NycBank.Domain.Handlers;
using NycBank.Domain.Repository;
using System;
using System.Collections.Generic;

namespace NycBank.Api.Controllers
{
    public class ProdutoController : Controller
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Produto> GetAll(
            [FromServices] IProdutoRepository repository)
        {
            return repository.GetList();
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CreateProduto(
        [FromBody] CreateProdutoCommand command,
        [FromServices] ProdutoHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("{nome:string}")]
        [HttpGet]
        public IActionResult GetName(string nome,
        [FromServices] IProdutoRepository repository)
        {
            var nomeProduto = repository.GetName(nome);
            return Ok(nomeProduto);

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
