using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Domain.Commands.Grupo.AdicionarGrupo
{
    public class AdicionarGrupoRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public Enums.EnumNicho Nicho { get; set; }
        public Guid? IdUsuario { get; set; }
    }
}
