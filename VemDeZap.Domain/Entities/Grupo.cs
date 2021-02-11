using VemDeZap.Domain.Enums;

namespace VemDeZap.Domain.Entities
{
    public class Grupo : Base.EntityBase
    {
        protected Grupo()
        {

        }

        public Grupo(string nome, EnumNicho nicho, Usuario usuario)
        {
            Nome = nome;
            Nicho = nicho;
            Usuario = usuario;
        }

        public string Nome { get; set; }
        public EnumNicho Nicho { get; set; }
        public Usuario Usuario { get; set; }

    }
}
