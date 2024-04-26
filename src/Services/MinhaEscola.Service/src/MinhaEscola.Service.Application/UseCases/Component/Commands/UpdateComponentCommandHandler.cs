using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Component.Commands
{
    public class UpdateComponentCommandHandler : CommandHandler, IRequestHandler<UpdateComponentRequest, ApiResponse>
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;

        public UpdateComponentCommandHandler(IComponentRepository componentRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _componentRepository = componentRepository;
            _unitOfWorkResource = unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(UpdateComponentRequest request, CancellationToken cancellationToken)
        {
            var component = await _componentRepository.GetElementById(request.Id);

            component?.Update(request.Name, request.DenominationId, request.TypeOrganization, request.StageId, request.ModalityId);

            _componentRepository.Update(component!);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
