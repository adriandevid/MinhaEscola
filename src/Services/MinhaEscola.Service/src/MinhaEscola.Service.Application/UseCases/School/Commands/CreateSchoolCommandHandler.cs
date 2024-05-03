using MediatR;
using Microsoft.AspNetCore.Http;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Infrastructure.Commom;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class CreateSchoolCommandHandler : CommandHandler, IRequestHandler<CreateSchoolRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateSchoolCommandHandler(IUnitOfWorkResource unitOfWorkResource, ISchoolRepository schoolRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWorkResource;
            _schoolRepository = schoolRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> Handle(CreateSchoolRequest request, CancellationToken cancellationToken)
        {
            var address = new Domain.Core.Address.Limits.Address(request.Address.Street, request.Address.CEP, request.Address.Neighborhood, request.Address.ZoneId);

            var school = new Domain.Board.School.Limits.School(request.Name, request.NameAbbreviated, request.SituationOfOperationId, request.DependencyAdministrativeId, request.CategorySchoolPrivatedId, request.CNPJ, request.AgencyPublicId, address, request.TypeOrganization);

            school.AssignUserToSchool(_httpContextAccessor.GetUserId());

            _schoolRepository.Create(school);

            return await CustomResponse(_unitOfWork);
        }
    }
}
