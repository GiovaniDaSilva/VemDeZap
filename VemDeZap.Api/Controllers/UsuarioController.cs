using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Commands.Usuario.AdicionarUsuario;
using VemDeZap.Infra.Repositories.Transactions;

namespace VemDeZap.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsuarioController : Base.ControllerBase
    {
        #region "Exemplos Simples"
        //[HttpGet]
        //[AllowAnonymous]
        //[Route("GetSimples")]
        //public string GetSimples()
        //{
        //    return "Chegou meu Get";
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("GetAutenticado")]
        //public string GetAutenticado()
        //{
        //    return "Chegou um Get Autenticado.";
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("Post")]
        //public string Post()
        //{
        //    return "Chegou um Post";
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("Put")]
        //public string Put()
        //{
        //    return "Chegou um Put";
        //}

        //[HttpDelete]
        //[AllowAnonymous]
        //[Route("Delete")]
        //public string Delete()
        //{
        //    return "Chegou um Delete";
        //}
        #endregion

        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Versao")]
        public string Versao()
        {            
         return "VemDeZap v. 1.0.0";            
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioRequest request)
        {
            try
            {

                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
