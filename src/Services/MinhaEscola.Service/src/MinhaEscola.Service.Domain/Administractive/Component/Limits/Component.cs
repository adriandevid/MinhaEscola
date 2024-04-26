using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Base.EnumTypes;
using MinhaEscola.Service.Domain.Administractive.Component.Events;
using MinhaEscola.Service.Domain.Academic.Class.Limits;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Domain.Administractive.Component.Limits
{
    public class Component : Entity, IAggregateRoot
    {
        public Component() { }

        public Component(string name, long denomination, TypeOrganization typeOrganization, long stageId, long modalityId)
        {
            Name = name;
            DenominationId = denomination;
            TypeOrganization = typeOrganization;
            StageId = stageId;
            ModalityId = modalityId;
            AppendEvent(new CreatedComponentDomainEvent(name, denomination, typeOrganization, stageId, modalityId));
        }

        public string Name { get; set; }
        public long DenominationId { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public long StageId { get; set; }
        public long ModalityId { get; set; }

        public Stage.Limits.Stage Stage { get; set; }
        public Modality.Limits.Modality Modality { get; set; }
        public Denomination Denomination { get; set; }

        public List<Class> Classes { get; set; }
        public List<SchoolComponent> SchoolComponent { get; set; }
        public List<DisciplineComponent> DisciplineComponents { get; set; }

        public void Update(string name, long denomination, TypeOrganization typeOrganization, long stageId, long modalityId)
        {
            Name = name;
            DenominationId = denomination;
            TypeOrganization = typeOrganization;
            StageId = stageId;
            ModalityId = modalityId;

            AppendEvent(new UpdateComponentDomainEvent(name, denomination, typeOrganization, stageId, modalityId));
        }
    }
}
