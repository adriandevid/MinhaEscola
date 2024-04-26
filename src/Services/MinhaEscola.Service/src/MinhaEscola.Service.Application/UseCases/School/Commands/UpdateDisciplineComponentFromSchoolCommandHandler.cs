using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Domain.Board.School.ValueObject;
using Microsoft.AspNetCore.Http;
using MinhaEscola.Service.Infrastructure.Commom;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class UpdateDisciplineComponentFromSchoolCommandHandler : CommandHandler, IRequestHandler<UpdateDisciplineComponentFromSchoolRequest, ApiResponse>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly IHttpContextAccessor _httpContext;


        public UpdateDisciplineComponentFromSchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWorkResource unitOfWorkResource, IHttpContextAccessor httpContext)
        {
            _schoolRepository = schoolRepository;
            _unitOfWorkResource = unitOfWorkResource;
            _httpContext = httpContext;
        }


        public async Task<ApiResponse> Handle(UpdateDisciplineComponentFromSchoolRequest request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.GetSchoolByUserReference(_httpContext.GetUserId());

            WorkLoad workload = WorkLoad.Parse(request.WeeklyClass, request.AnnualClass, request.WeekHours);

            school.UpdateDisciplineComponent(request.Id, workload);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
