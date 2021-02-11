namespace VemDeZap.Domain.Entities
{
    public class Campanha : Base.EntityBase
    {
        protected Campanha()
        {
        }

        public Campanha(string nome, Usuario usuario)
        {
            Nome = nome;
            Usuario = usuario;
        }

        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
    }
}
