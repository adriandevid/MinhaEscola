using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class RemoveComponentSchoolCommandHandler : CommandHandler, IRequestHandler<RemoveComponentSchoolRequest, ApiResponse>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;

        public RemoveComponentSchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _schoolRepository = schoolRepository;
            _unitOfWorkResource = unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(RemoveComponentSchoolRequest request, CancellationToken cancellationToken)
        {
            var schoolComponent = await _schoolRepository.GetSchoolById(request.SchoolId);

            schoolComponent!.RemoveComponent(request.Id);
            
            _schoolRepository.Update(schoolComponent);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
