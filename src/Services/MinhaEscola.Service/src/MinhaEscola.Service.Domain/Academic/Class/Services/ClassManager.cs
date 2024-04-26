using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Domain.Academic.Class.Services
{
    public class ClassManager : IClassManager
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IClassRepository _classRepository;

        public ClassManager(ISchoolRepository schoolRepository, IComponentRepository componentRepository, IClassRepository classRepository)
        {
            _schoolRepository = schoolRepository;
            _componentRepository = componentRepository;
            _classRepository = classRepository;
        }

        public async Task Create(long schoolId, Limits.Class @class)
        {
            School school = await _schoolRepository.GetSchoolById(schoolId);

            Component? component = await _componentRepository.GetElementById(@class.ComponentId);

            if (!school.IsActivatedSchool())
                throw new InvalidOperationException("This school are inactive!");

            if ((int)component!.TypeOrganization != (int)school.TypeOrganization)
            {
                throw new InvalidOperationException("This component selected not is valid please!");
            }

            _classRepository.Create(@class);
        }

        public async Task Update(long schoolId, Limits.Class @class)
        {
            School school = await _schoolRepository.GetSchoolById(schoolId);

            Component? component = await _componentRepository.GetElementById(@class.ComponentId);

            if (!school.IsActivatedSchool())
                throw new InvalidOperationException("This school are inactive!");

            if ((int)component!.TypeOrganization != (int)school.TypeOrganization)
            {
                throw new InvalidOperationException("This component selected not is valid please!");
            }

            _classRepository.Update(@class);
        }
    }
}
