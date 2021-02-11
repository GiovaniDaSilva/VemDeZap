using prmToolkit.NotificationPattern;
using VemDeZap.Domain.Enums;

namespace VemDeZap.Domain.Entities
{
    public class Grupo : Base.EntityBase
    {
        protected Grupo(){}

        public Grupo(string nome, EnumNicho nicho, Usuario usuario)
        {
            Nome = nome;
            Nicho = nicho;
            Usuario = usuario;

            ValidarGrupo();
        }

        public string Nome { get; set; }
        public EnumNicho Nicho { get; set; }
        public Usuario Usuario { get; set; }


        private void ValidarGrupo()
        {
            new AddNotifications<Grupo>(this)
                //.IfTrue(x => x.Usuario == null, Strings.Strings.UsuarioNaoInformado)
                .IfNullOrInvalidLength(x => x.Nome, 3, 150)                                
                .IfEnumInvalid(x => x.Nicho);
        }
    }
}
