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
        [Route("produto")]
        [HttpGet]
        public IEnumerable<Produto> GetAllProduto(
            [FromServices] IProdutoRepository repository)
        {
            return repository.GetList();
        }

        [Route("produto")]
        [HttpPost]
        public GenericCommandResult CreateProduto(
        [FromBody] CreateProdutoCommand command,
        [FromServices] ProdutoHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("produto/{nome:alpha}")]
        [HttpGet]
        public IActionResult GetProduto(string nome,
        [FromServices] IProdutoRepository repository)
        {
            var nomeProduto = repository.GetName(nome);
            return Ok(nomeProduto);

        }

        [Route("produto")]
        [HttpPut]
        public GenericCommandResult UpdateProduto(
        [FromBody] UpdateProdutoCommand command,
        [FromServices] ProdutoHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }

        [Route("produto/categoria")]
        [HttpPut]
        public GenericCommandResult AddCategoria(
        [FromBody] ProdutoAddCategoriaCommand command,
        [FromServices] ProdutoHandler handle)
        {
            return (GenericCommandResult)handle.Handle(command);
        }



        [Route("produto/{id:guid}")]
        [HttpDelete]
        public IActionResult DelProduto(Guid id,
        [FromServices] IProdutoRepository repository)
        {
            repository.Delete(id);
            return NoContent();
        }



    }
}
