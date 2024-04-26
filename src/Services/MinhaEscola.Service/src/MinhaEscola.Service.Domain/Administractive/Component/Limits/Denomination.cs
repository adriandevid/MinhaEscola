using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Administractive.Component.Limits
{
    public class Denomination : Entity
    {
        public Denomination() { }

        public string Description { get; set; }
        public List<Component> Components { get; set; }
    }
}
