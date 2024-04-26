using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Stage.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Stage.Commands
{
    public class CreateStageCommandHandler : CommandHandler, IRequestHandler<CreateStageRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;

        public CreateStageCommandHandler(IUnitOfWorkResource unitOfWorkResource, IStageRepository stageRepository, IMapper mapper)
        {
            _unitOfWorkResource = unitOfWorkResource;
            _stageRepository = stageRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateStageRequest request, CancellationToken cancellationToken)
        {
            var stage = _mapper.Map<Domain.Administractive.Stage.Limits.Stage>(request);
            
            _stageRepository.Create(stage);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
