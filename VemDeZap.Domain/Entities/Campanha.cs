namespace VemDeZap.Domain.Entities
{
    public class Campanha : Base.EntityBase
    {        
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
    }
}
