using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Base.EnumTypes;
using MinhaEscola.Service.Domain.Board.School.Events;
using MinhaEscola.Service.Domain.Board.School.ValueObject;
using MinhaEscola.Service.Domain.Academic.Class.Limits;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;

namespace MinhaEscola.Service.Domain.Board.School.Limits
{
    public class School : Entity, IAggregateRoot
    {
        public School() { }

        public School(
            string name,
            string nameAbbreviated, SituationOperation situationOfOperationId,
            DepencyAdministractive dependecyAdministrativeId, CategoryOfSchoolPrivated categorySchoolPrivatedId,
            string cnpj, long agencyPublicId, Core.Address.Limits.Address address,
            TypeOrganization typeOrganization
        )
        {
            Name = name;
            NameAbbreviated = nameAbbreviated;
            SituationOfOperationId = situationOfOperationId;
            DependencyAdministrativeId = dependecyAdministrativeId;
            CategorySchoolPrivatedId = categorySchoolPrivatedId;
            CNPJ = cnpj;
            AgencyPublicId = agencyPublicId;
            Address = address;
            TypeOrganization= typeOrganization;

            AppendEvent(new SchoolCreatedDomainEvent()
            {
                Name = name,
                NameAbbreviated = nameAbbreviated,
                SituationOfOperationId = (long)situationOfOperationId
            });
        }

        public long AddressId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviated { get; set; }
        public SituationOperation SituationOfOperationId { get; set; }
        public DepencyAdministractive DependencyAdministrativeId { get; set; }
        public CategoryOfSchoolPrivated CategorySchoolPrivatedId { get; set; }
        public TypeOrganization TypeOrganization { get; set; }

        public string CNPJ { get; set; }
        public long AgencyPublicId { get; set; }

        private int _status = (int)StatusOfSchool.Waiting;
        public int Status { get { return _status; } }

        //private List<Student.Limits.Student> _students = new();
        private readonly List<SchoolComponent> _schoolComponents = new();
        private readonly List<DisciplineComponent> _disciplineComponents = new();
        private readonly List<Class> _classes = new();
        private readonly List<UserSchool> _userSchool = new();


        //public IReadOnlyList<Student.Limits.Student> Students => _students.AsReadOnly();
        public IReadOnlyCollection<SchoolComponent> SchoolComponents => _schoolComponents.AsReadOnly();
        public IReadOnlyCollection<DisciplineComponent> DisciplineComponents => _disciplineComponents.AsReadOnly();
        public IReadOnlyCollection<Class> Classes => _classes.AsReadOnly();
        public IReadOnlyCollection<UserSchool> UsersSchool => _userSchool.AsReadOnly();

        public Core.Address.Limits.Address Address { get; set; }
        public PublicAgency.Limits.PublicAgency PublicAgencyRelated { get; set; }

        public void RemoveComponent(long id) 
        {
            ValidateOperationException();
            
            AppendEvent(new RemoveComponentSchoolDomainEvent() { Id = id });
            _schoolComponents.Remove(_schoolComponents.First(x => x.Id == id));
        }

        public void RemoveDisciplineComponent(long id)
        {
            ValidateOperationException();

            AppendEvent(new RemoveDisciplineComponentDomainEvent() { Id = id });

            _disciplineComponents.Remove(_disciplineComponents.First(x => x.Id == id));
        }

        public void AssignComponent(Component component)
        {
            ValidateOperationException();

            if (_schoolComponents.Any(x => component.Id == x.ComponentId))
                throw new InvalidOperationException("This component already!");

            if (!((int)component.TypeOrganization == (int)TypeOrganization))
                throw new InvalidOperationException("This component not is valid to assign!");

            AppendEvent(new CreateSchoolComponentDomainEvent() { ComponentId = component.Id, SchoolId = Id, Name = component.Name });

            _schoolComponents.Add(new SchoolComponent(Id, component.Id));
        }

        public void AssignDisciplineComponent(DisciplineComponent disciplineComponent)
        {
            ValidateOperationException();

            if (_disciplineComponents.Any(x => disciplineComponent.ComponentId == x.ComponentId && disciplineComponent.DisciplineId == x.DisciplineId))
                throw new InvalidOperationException("This component already have this discipline!");

            AppendEvent(new CreateSchoolDisciplineComponentDomainEvent() { ComponentId = disciplineComponent.ComponentId, SchoolId = Id });

            _disciplineComponents.Add(disciplineComponent);
        }

        public void UpdateDisciplineComponent(long disciplineComponentId, WorkLoad workload) 
        {
            var discipline = _disciplineComponents.FirstOrDefault(x => x.Id == disciplineComponentId);

            ValidateOperationException();

            if (discipline == null)
                throw new InvalidOperationException("This discpline not found");

            discipline!.Update(workload);
        }

        public void AssignUserToSchool(string user) 
        {
            _userSchool.Add(new UserSchool(user));
        }

        public void ActiveSchool()
        {
            AppendEvent(new ActiveSchoolDomainEvent() { Id = Id });
            _status = (int)StatusOfSchool.Active;
        }

        public void InactiveSchool()
        {
            _status = (int)StatusOfSchool.Inactive;
            AppendEvent(new InactiveSchoolDomainEvent() { Id = Id });
        }

        public bool IsActivatedSchool() => _status == (int)StatusOfSchool.Active;

        public void Update(string name, string nameAbbreviated, string cpnj)
        {
            ValidateOperationException();

            AppendEvent(new UpdateSchoolDomainEvent() { Id = Id });

            Name = name;
            NameAbbreviated = nameAbbreviated;
            CNPJ = cpnj;
        }

        public void ValidateOperationException() {
            if (!IsActivatedSchool())
                throw new InvalidOperationException("This opertaion invalid!");
        }
    }
}


