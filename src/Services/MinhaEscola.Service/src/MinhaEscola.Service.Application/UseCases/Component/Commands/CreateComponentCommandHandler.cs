using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;
using MinhaEscola.Service.Domain.Base.EnumTypes;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Modality.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Stage.Interfaces;
using ComponentEntitie = MinhaEscola.Service.Domain.Administractive.Component.Limits.Component;

namespace MinhaEscola.Service.Application.UseCases.Component.Commands
{
    public class CreateComponentCommandHandler : CommandHandler, IRequestHandler<CreateComponentRequest, ApiResponse>
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly IModalityRepository _modalityRepository;
        private readonly IStageRepository _stageRepository;

        public CreateComponentCommandHandler(IComponentRepository componentRepository, IUnitOfWorkResource unitOfWorkResource, IModalityRepository modalityRepository, IStageRepository stageRepository) { 
            _componentRepository= componentRepository;
            _unitOfWorkResource= unitOfWorkResource;
            _modalityRepository= modalityRepository;
            _stageRepository= stageRepository;
        }

        public async Task<ApiResponse> Handle(CreateComponentRequest request, CancellationToken cancellationToken)
        {
            var modalidality = await _modalityRepository.GetElementById(request.ModalityId);
            var stage = await _stageRepository.GetByIdWithAllIncludes(request.StageId);
            var denominations = await _componentRepository.GetDenominationById(request.DenominationId);

            if (request.TypeOrganization == TypeOrganization.School) { 
                request.Name = denominations.Description + " / " + stage.Description + " / " + stage.LevelEducation.Description + " / " + modalidality.Description;
            }

            var component = new ComponentEntitie(request.Name, request.DenominationId, request.TypeOrganization, request.StageId, request.ModalityId);
            
            _componentRepository.Create(component);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
