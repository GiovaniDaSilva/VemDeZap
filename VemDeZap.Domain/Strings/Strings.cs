using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Resource;

namespace VemDeZap.Domain.Strings
{
    public static class Strings
    {
        //Exemplo da utilização da mensagem por resource, ou direto na classe.

        public static readonly string InformeOsDadosDoUsuario = $"Informe os dados do usuário.";
        public static readonly string EmailJaCadastradoNoSistema = $"E-mail já cadastrado no sistema.";
        public static readonly string OPrimeiroNomeDeveConter3A150Caracter = $"O primeiro nome deve conter entre 3 a 150 caracteres.";
        public static readonly string InformeOsDadosDoGrupo = $"Informe os dados do grupo.";
        public static readonly string UsuarioNaoInformado = MSG.X0_NAO_INFORMADO.ToFormat("Usuario");
        public static readonly string GrupoNaoInformado = MSG.X0_NAO_INFORMADO.ToFormat("Grupo");
    }
}
