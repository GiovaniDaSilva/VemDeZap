using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Domain.Commands.Grupo.RemoverGrupo
{
    public class RemoverGrupoRequest : IRequest<Response>
    {
        public RemoverGrupoRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
