using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class RemoveDisciplineComponentFromSchoolCommandHandler : CommandHandler, IRequestHandler<RemoveDisciplineComponentFromSchoolRequest, ApiResponse>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        public RemoveDisciplineComponentFromSchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _schoolRepository = schoolRepository;
            _unitOfWorkResource = unitOfWorkResource;
        }


        public async Task<ApiResponse> Handle(RemoveDisciplineComponentFromSchoolRequest request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.GetSchoolById(request.SchoolId);
            school.RemoveDisciplineComponent(request.Id);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
