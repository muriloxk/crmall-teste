using System;
using Crmall.Domain.Entities.ObjectValues;
using Crmall.Infra.ViaCep;
using Microsoft.AspNetCore.Mvc;

namespace Crmall.Api.Controllers
{
    [ApiController]
    [Route("cep")]
    public class CepController : ControllerBase
    {
        [HttpGet]
        [Route("{cep}")]
        public IActionResult BuscarCep(string cep,
                                      [FromServices] BuscadorDeCep buscadorCep)
        {
            var resultado = buscadorCep.BuscarCep(cep);

            if (resultado == null)
              return NotFound();

            return Ok(resultado);
        }
    }
}
