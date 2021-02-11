using prmToolkit.NotificationPattern;
using System;
using VemDeZap.Domain.Extensions;

namespace VemDeZap.Domain.Entities
{
    public class Usuario : Base.EntityBase
    {
        protected Usuario()
        {
        }


        public Usuario(string primeiroNome, string ultimoNome, string email, string senha)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Email = email;
            Senha = senha;

            ValidarUsuario();

            if (SenhaInformada()) Senha = Senha.ConvertToMD5();
            DataCadastro = DateTime.Now;
            Ativo = false;
        }

        private void ValidarUsuario()
        {
            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 150, Strings.Strings.OPrimeiroNomeDeveConter3A150Caracter)
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 150)
                .IfNotEmail(x => x.Email)
                .IfNullOrInvalidLength(x => x.Senha, 3, 32);           
        }

        private bool SenhaInformada()
        {
            return (!string.IsNullOrEmpty(this.Senha));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
    }
}
