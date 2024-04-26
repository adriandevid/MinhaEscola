using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Class.Commands
{
    public class CreateClassCommandHandler : CommandHandler, IRequestHandler<CreateClassRequest, ApiResponse>
    {
        private readonly IClassManager _classManager;
        private readonly IUnitOfWorkResource _unitOfWork;

        public CreateClassCommandHandler(IClassManager classManager, IUnitOfWorkResource unitOfWorkResource)
        {
            _classManager = classManager;
            _unitOfWork = unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(CreateClassRequest request, CancellationToken cancellationToken)
        {
            var classEntity = new Domain.Academic.Class.Limits.Class(request.AmountStudent, true, request.Denomination, request.ComponentId, request.Year, request.SchoolId);

            await _classManager.Create(request.SchoolId, classEntity);

            return await CustomResponse(_unitOfWork);
        }
    }
}
