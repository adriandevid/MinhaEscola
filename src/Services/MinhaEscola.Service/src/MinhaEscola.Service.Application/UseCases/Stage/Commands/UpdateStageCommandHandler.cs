using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Stage.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Stage.Commands
{
    public class UpdateStageCommandHandler : CommandHandler, IRequestHandler<UpdateStageRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;

        public UpdateStageCommandHandler(IUnitOfWorkResource unitOfWorkResource, IStageRepository stageRepository, IMapper mapper)
        {
            _unitOfWorkResource = unitOfWorkResource;
            _stageRepository = stageRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateStageRequest request, CancellationToken cancellationToken)
        {
            var stageDestination = await _stageRepository.GetElementById(request.Id);

            var stageModify = _mapper.Map(request, stageDestination);

            _stageRepository.Update(stageModify);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
