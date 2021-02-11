﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Commands.Grupo.AdicionarGrupo;
using VemDeZap.Domain.Commands.Grupo.ListarGrupo;
using VemDeZap.Domain.Commands.Usuario.AutenticarUsuario;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.Api.Controllers
{
    public class GrupoController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public GrupoController(IHttpContextAccessor httpContextAccessor, IMediator mediator,  IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Grupo/Listar")]
        public async Task<IActionResult> ListarGrupo()
        {
            try
            {
                var request = new ListarGrupoRequest();
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Authorize]
        [HttpPost]
        [Route("api/Grupo/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarGrupoRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                request.IdUsuario = usuarioResponse.Id;

                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Authorize]
        [HttpDelete]
        [Route("api/Grupo/Remover/{id:Guid}")]
        public async Task<IActionResult> RemoverGrupo(Guid id)
        {
            try
            {
                //var request = new RemoverGrupoRequest();
                //var result = await _mediator.Send(Request, CancellationToken.None);
                return Ok("Entrou no Delete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
