using Exemplo.Clientes.API.Application.Commands;
using Exemplo.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Exemplo.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), "Thiago Nishio", "thiago.nishio@soulisto.com.br", "82445421365"));

            return Ok(resultado);
        }
    }
}