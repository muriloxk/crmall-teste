using System;
using System.Collections.Generic;
using Crmall.Domain.Commands;
using Crmall.Domain.Contracts.Handler;
using Crmall.Domain.Contracts.Repository;
using Crmall.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Crmall.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public ResultadoGenerico Novo(
            [FromBody]NovoClienteCommand comando,
            [FromServices]ClienteHandler handler)
        {
            return (ResultadoGenerico)handler.Executar(comando); 
        }

        [Route("")]
        [HttpPut]
        public ResultadoGenerico Atualizar(
            [FromBody]AtualizarClienteCommand comando,
            [FromServices]ClienteHandler handler)
        {
            return (ResultadoGenerico)handler.Executar(comando);
        }

        [Route("")]
        [HttpDelete]
        public ResultadoGenerico Remover(
            [FromBody]RemoverClienteCommand comando,
            [FromServices]ClienteHandler handler)
        {
            return (ResultadoGenerico)handler.Executar(comando);
        }

        [Route("todos")]
        [HttpGet]
        public IEnumerable<Cliente> BuscarTodos(
            [FromServices] IClienteRepository repository)
        {
            return repository.BuscarTodos();
        }

        [Route("")]
        [HttpGet]
        public IActionResult BuscarPorId(
        [FromQuery] string id,
        [FromServices] IClienteRepository repository)
        {
            var cliente = repository.BuscarPorId(Guid.Parse(id));

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }
}
