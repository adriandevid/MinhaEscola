using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class AppendSchoolComponentCommandHandler : CommandHandler, IRequestHandler<AppendSchoolComponentRequest, ApiResponse>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        public AppendSchoolComponentCommandHandler(ISchoolRepository schoolRepository, IUnitOfWorkResource unitOfWorkResource, IComponentRepository componentRepository)
        {
            _schoolRepository = schoolRepository;
            _unitOfWorkResource = unitOfWorkResource;
            _componentRepository = componentRepository;
        }

        public async Task<ApiResponse> Handle(AppendSchoolComponentRequest request, CancellationToken cancellationToken)
        {
            Domain.Board.School.Limits.School school = await _schoolRepository.GetSchoolById(request.SchoolId);
            Domain.Administractive.Component.Limits.Component component = await _componentRepository.GetElementById(request.ComponentId);

            school?.AssignComponent(component);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
