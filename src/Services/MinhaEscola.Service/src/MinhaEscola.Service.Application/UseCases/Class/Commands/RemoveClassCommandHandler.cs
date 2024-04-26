using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Class.Commands
{
    public class RemoveClassCommandHandler : CommandHandler, IRequestHandler<RemoveClassRequest, ApiResponse>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public RemoveClassCommandHandler(IClassRepository classRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _classRepository= classRepository;
            _unitOfWork= unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(RemoveClassRequest request, CancellationToken cancellationToken)
        {
            Domain.Academic.Class.Limits.Class @class = await _classRepository.GetElementById(request.Id);
            
            _classRepository.Delete(@class);

            return await CustomResponse(_unitOfWork);
        }
    }
}
