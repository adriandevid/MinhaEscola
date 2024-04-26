using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Commands
{
    public class CreateLevelEducationCommandHandler : CommandHandler, IRequestHandler<CreateLevelEducationRequest, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly ILevelEducationRepository _levelEducationRepository;

        public CreateLevelEducationCommandHandler(IMapper mapper, IUnitOfWorkResource unitOfWorkResource, ILevelEducationRepository levelEducationRepository)
        {
            _mapper = mapper;
            _unitOfWorkResource = unitOfWorkResource;
            _levelEducationRepository = levelEducationRepository;
        }

        public async Task<ApiResponse> Handle(CreateLevelEducationRequest request, CancellationToken cancellationToken)
        {
            var levelEducation = _mapper.Map<Domain.Administractive.LevelEducation.Limits.LevelEducation>(request);

            _levelEducationRepository.Create(levelEducation);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
