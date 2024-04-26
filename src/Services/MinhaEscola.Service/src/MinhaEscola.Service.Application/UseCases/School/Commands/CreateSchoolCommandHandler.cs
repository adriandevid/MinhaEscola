using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class CreateSchoolCommandHandler : CommandHandler, IRequestHandler<CreateSchoolRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly ISchoolRepository _schoolRepository;

        public CreateSchoolCommandHandler(IUnitOfWorkResource unitOfWorkResource, ISchoolRepository schoolRepository)
        {
            _unitOfWork = unitOfWorkResource;
            _schoolRepository = schoolRepository;
        }

        public async Task<ApiResponse> Handle(CreateSchoolRequest request, CancellationToken cancellationToken)
        {
            var address = new Domain.Core.Address.Limits.Address(request.Address.Street, request.Address.CEP, request.Address.Neighborhood, request.Address.ZoneId);

            var school = new Domain.Board.School.Limits.School(request.Name, request.NameAbbreviated, request.SituationOfOperationId, request.DependencyAdministrativeId, request.CategorySchoolPrivatedId, request.CNPJ, request.AgencyPublicId, address, request.TypeOrganization);

            school.AssignUserToSchool(request.UserReference);

            _schoolRepository.Create(school);

            return await CustomResponse(_unitOfWork);
        }
    }
}
