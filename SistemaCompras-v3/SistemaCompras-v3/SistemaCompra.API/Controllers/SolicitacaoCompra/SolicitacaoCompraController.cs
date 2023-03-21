using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.API.Controllers.Base;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Application.Validadores;
using System;
using System.Threading.Tasks;

namespace SistemaCompra.API.Controllers.SolicitacaoCompra
{
    [ApiController]
    public class SolicitacaoCompraController : BaseController
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
        [HttpPost("solicitacao/compra")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> RegistraCompraAsync([FromBody, CustomizeValidator(RuleSet = ValidationRules.Incluir)] RegistrarCompraCommand request)
           => GetResponse(await _mediator.Send(request));
    }
}
