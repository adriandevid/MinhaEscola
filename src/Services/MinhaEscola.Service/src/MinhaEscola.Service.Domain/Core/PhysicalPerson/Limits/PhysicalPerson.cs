using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Events;
using MinhaEscola.Service.Domain.Academic.Student.Limits;
using System.Collections.Generic;
using MinhaEscola.Service.Domain.Administractive.Sex.Limits;
using MinhaEscola.Service.Domain.Administractive.Color.Limits;
using MinhaEscola.Service.Domain.Administractive.Nationality.Limits;

namespace MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits
{
    public class PhysicalPerson : Entity, IAggregateRoot
    {
        public PhysicalPerson()
        {

        }

        public PhysicalPerson(string? name, int year, string? registerOfPhysicalPerson, Core.Address.Limits.Address address, long sexId, long colorId, string? registerGeneral, long nationalityId)
        {
            Name = name;
            Year = year;
            RegisterOfPhysicalPerson = registerOfPhysicalPerson;
            Address = address;
            SexId = sexId;
            ColorId = colorId;
            RegisterGeneral = registerGeneral;
            NationalityId = nationalityId;

            AppendEvent(new CreatedPhysicalPersonEvent(name, year, registerOfPhysicalPerson, sexId, colorId, registerGeneral, nationalityId));
        }

        public string? Name { get; set; }
        public int Year { get; set; }
        public string? RegisterOfPhysicalPerson { get; set; }
        public long AddressId { get; set; }
        public long SexId { get; set; }
        public long ColorId { get; set; }
        public string? RegisterGeneral { get; set; }
        public long NationalityId { get; set; }


        private readonly List<Documentation> _documentations = new List<Documentation>();
        private readonly List<Affiliation.Limits.Affiliation> _affiliations = new List<Affiliation.Limits.Affiliation>();

        public Sex? Sex { get; set; }
        public Color? Color { get; set; }
        public Core.Address.Limits.Address? Address { get; set; }
        public Nationality Nationality { get; set; }
        public List<Student> Students { get; set; }
        public IReadOnlyCollection<Documentation> Documentations => _documentations.AsReadOnly();
        public IReadOnlyCollection<Affiliation.Limits.Affiliation> Affiliations => _affiliations.AsReadOnly();


        public void AppendDocumentation(Documentation documentacao)
        {
            AppendEvent(new AppendDocumentationToPhysicalPersonEvent());

            _documentations.Add(documentacao);
        }

        public void AppendAffiliation(Affiliation.Limits.Affiliation filiacao)
        {
            if (_affiliations.Any(x => x.RelatedId == filiacao.RelatedId))
                throw new InvalidOperationException("this person is already related.");

            _affiliations.Add(filiacao);

            AppendEvent(new AppendAffiliationToPhysicalPersonEvent());
        }

        public bool ValidateDocumentations()
        {
            if (_documentations.Any(x => x.DocumentationValid == false)) { return false; }
            else
            {
                return true;
            }
        }

        public void DocumentationIsValid(long id)
        {
            var documentation = _documentations.FirstOrDefault(x => x.Id == id);

            if (documentation == null)
                throw new InvalidOperationException("This document not already, sorry!");

            documentation.ValidateDocumentation();
        }

        public void Update(string? name, int year, string? registerOfPhysicalPerson, long sexId, long colorId, string? registerGeneral, long nationalityId)
        {
            if (ValidateDocumentations())
                throw new InvalidOperationException("this person have with document invalid!");

            Name = name;
            Year = year;
            RegisterOfPhysicalPerson = registerOfPhysicalPerson;
            SexId = sexId;
            ColorId = colorId;
            RegisterGeneral = registerGeneral;
            NationalityId = nationalityId;
        }

    }
}
