using System;

namespace VemDeZap.Domain.Entities
{
    public class Envio : Base.EntityBase

    {        
        public Campanha Campanha { get; set; }
        public Grupo Grupo { get; set; }
        public Contato Contato { get; set; }
        public bool Enviado { get; set; }

    }
}
