using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Domain.Board.School.ValueObject;
using MinhaEscola.Service.Infrastructure.Commom;
using Microsoft.AspNetCore.Http;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class AppendDisciplineComponentCommandHandler : CommandHandler, IRequestHandler<AppendDisciplineComponentRequest, ApiResponse>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly IHttpContextAccessor _contextHttp;

        public AppendDisciplineComponentCommandHandler(ISchoolRepository schoolRepository, IUnitOfWorkResource unitOfWorkResource, IHttpContextAccessor contextHttp)
        {
            _schoolRepository= schoolRepository;   
            _unitOfWorkResource= unitOfWorkResource;
            _contextHttp = contextHttp;
        }

        public async Task<ApiResponse> Handle(AppendDisciplineComponentRequest request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.GetSchoolByUserReference(_contextHttp.GetUserId());

 
            WorkLoad workload = WorkLoad.Parse(request.WeeklyClass, request.AnnualClass, request.WeekHours);

            school?.AssignDisciplineComponent(new Domain.Board.School.Limits.DisciplineComponent(request.ComponentId, request.DisciplineId, workload, school.Id));

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
