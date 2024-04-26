
using MediatR;
using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Board.School.Events
{
    public class SchoolCreatedDomainEvent : IEvent
    {
        public SchoolCreatedDomainEvent() { }

        public long Id { get; set; }
        public long AddressId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviated { get; set; }
        public long SituationOfOperationId { get; set; }
        public long DependencyAdministrativeId { get; set; }
        public long CategorySchoolPrivatedId { get; set; }
        public string CNPJ { get; set; }
        public long AgencyPublicId { get; set; }
        public long LocationOfOperationId { get; set; }
    }
}
