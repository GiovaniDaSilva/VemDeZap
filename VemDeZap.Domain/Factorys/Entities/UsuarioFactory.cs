using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities;
using VemDeZap.Domain.Interfaces.Entities;

namespace VemDeZap.Domain.Factorys.Entities
{
    public static class UsuarioFactory
    {
        public static Usuario CreateInstace(string primeiroNome, string ultimoNome, string email, string senha)
        {
            return new Usuario(primeiroNome, ultimoNome, email, senha);
        }
    }
}
