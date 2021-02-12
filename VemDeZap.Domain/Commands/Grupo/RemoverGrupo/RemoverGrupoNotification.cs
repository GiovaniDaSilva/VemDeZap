using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Domain.Commands.Grupo.RemoverGrupo
{
    
    public class RemoverGrupoNotification : INotification
    {
        public Entities.Grupo Grupo { get; set; }

        public RemoverGrupoNotification(Entities.Grupo grupo)
        {
            Grupo = grupo;
        }
    }
}
