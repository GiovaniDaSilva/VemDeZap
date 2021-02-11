using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VemDeZap.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        public string Get()
        {
            return "Chegou meu Get";
        }

        [HttpGet]
        [Authorize]
        [Route("GetAutenticado")]
        public string GetAutenticado()
        {
            return "Chegou um Get Autenticado.";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Post")]
        public string Post()
        {
            return "Chegou um Post";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Put")]
        public string Put()
        {
            return "Chegou um Put";
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("Delete")]
        public string Delete()
        {
            return "Chegou um Delete";
        }
    }
}
