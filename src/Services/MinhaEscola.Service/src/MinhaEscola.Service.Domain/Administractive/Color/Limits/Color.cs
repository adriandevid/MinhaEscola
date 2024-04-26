using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;

namespace MinhaEscola.Service.Domain.Administractive.Color.Limits
{
    public class Color : Entity
    {
        public Color()
        {

        }


        public string Description { get; set; }
        public List<PhysicalPerson> PhysicalPersons { get; set; }
    }
}
