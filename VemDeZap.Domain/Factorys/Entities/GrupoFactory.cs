using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities;

namespace VemDeZap.Domain.Factorys.Entities
{
    public class GrupoFactory
    {
        public static Grupo CreateInstace(string Nome, Enums.EnumNicho nicho, Usuario usuario)
        {
            return new Grupo(Nome, nicho, usuario);
        }
    }
}
