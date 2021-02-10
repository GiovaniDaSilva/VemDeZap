using VemDeZap.Domain.Enums;

namespace VemDeZap.Domain.Entities
{
    public class Grupo : Base.EntityBase
    {
        
        public string Nome { get; set; }
        public EnumNicho Nicho { get; set; }
        public Usuario Usuario { get; set; }

    }
}
