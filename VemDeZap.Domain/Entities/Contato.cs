using VemDeZap.Domain.Enums;

namespace VemDeZap.Domain.Entities
{
    public  class Contato : Base.EntityBase
    {
        protected Contato()
        {
        }

        public Contato(string nome, string telefone, EnumNicho nicho, Usuario usuario)
        {
            Nome = nome;
            Telefone = telefone;
            Nicho = nicho;
            Usuario = usuario;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnumNicho Nicho { get; set; }
        public Usuario Usuario { get; set; }

    }
}
