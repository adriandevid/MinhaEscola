using MinhaEscola.Service.Domain.Base.EnumTypes;
using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Administractive.Component.Events
{
    public class CreatedComponentDomainEvent : IEvent
    {
        public CreatedComponentDomainEvent()
        {

        }

        public CreatedComponentDomainEvent(string name, long denomination, TypeOrganization typeOrganization, long stageId, long modalityId)
        {
            Name = name;
            DenominationId = denomination;
            TypeOrganization = typeOrganization;
            StageId = stageId;
            ModalityId = modalityId;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long DenominationId { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public long StageId { get; set; }
        public long ModalityId { get; set; }
    }
}
