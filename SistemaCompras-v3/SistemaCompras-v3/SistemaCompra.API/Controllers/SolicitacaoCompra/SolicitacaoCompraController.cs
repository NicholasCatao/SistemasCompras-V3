using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;
using System;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using FluentValidation.AspNetCore;
using SistemaCompra.Application.Validadores;

namespace SistemaCompra.API.Controllers.SolicitacaoCompra
{
    [ApiController]
    public class SolicitacaoCompraController : Controller
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint responsável por registrar as solicitações de compra
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("solicitacao")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> RegistraCompraAsync([FromBody, CustomizeValidator(RuleSet = ValidationRules.Incluir)] RegistrarCompraCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
