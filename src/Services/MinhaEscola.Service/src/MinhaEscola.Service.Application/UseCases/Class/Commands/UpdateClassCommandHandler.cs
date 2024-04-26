using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Class.Commands
{
    public class UpdateClassCommandHandler : CommandHandler, IRequestHandler<UpdateClassRequest, ApiResponse>
    {
        private readonly IClassManager _classManager;
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly IClassRepository _classRepository;

        public UpdateClassCommandHandler(IClassManager classManager, IUnitOfWorkResource unitOfWorkResource, IClassRepository classRepository)
        {
            _classManager = classManager;
            _unitOfWork = unitOfWorkResource;
            _classRepository = classRepository;
        }

        public async Task<ApiResponse> Handle(UpdateClassRequest request, CancellationToken cancellationToken)
        {

            var classEntity = await _classRepository.GetElementById(request.Id);

            classEntity!.Update(request.AmountStudent, request.Denomination, request.Year);

            await _classManager.Update(request.SchoolId, classEntity);

            return await CustomResponse(_unitOfWork);
        }
    }
}
