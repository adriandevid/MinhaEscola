using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Commands
{
    public class UpdateLevelEducationCommandHandler : CommandHandler, IRequestHandler<UpdateLevelEducationRequest, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly ILevelEducationRepository _levelEducationRepository;

        public UpdateLevelEducationCommandHandler(IMapper mapper, IUnitOfWorkResource unitOfWorkResource, ILevelEducationRepository levelEducationRepository)
        {
            _mapper = mapper;
            _unitOfWorkResource = unitOfWorkResource;
            _levelEducationRepository = levelEducationRepository;
        }


        public async Task<ApiResponse> Handle(UpdateLevelEducationRequest request, CancellationToken cancellationToken)
        {
            var levelEducationDestination = await _levelEducationRepository.GetElementById(request.Id);
            
            _mapper.Map(request, levelEducationDestination);

            _levelEducationRepository.Update(levelEducationDestination);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
