using System;

namespace VemDeZap.Domain.Entities
{
    public class Envio : Base.EntityBase

    {
        protected Envio()
        {
        }

        public Envio(Campanha campanha, Grupo grupo, Contato contato, bool enviado)
        {
            Campanha = campanha;
            Grupo = grupo;
            Contato = contato;
            Enviado = enviado;
        }

        public Campanha Campanha { get; set; }
        public Grupo Grupo { get; set; }
        public Contato Contato { get; set; }
        public bool Enviado { get; set; }

    }
}
