using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Modality.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Modality.Commands
{
    public class CreateModalityCommandHandler : CommandHandler, IRequestHandler<CreateModalityRequest, ApiResponse>
    {
        private readonly IModalityRepository _modalityRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkResource _unitOfWork;

        public CreateModalityCommandHandler(IModalityRepository modalityRepository, IMapper mapper, IUnitOfWorkResource unitOfWorkResource) { 
            _modalityRepository= modalityRepository;
            _mapper= mapper;
            _unitOfWork= unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(CreateModalityRequest request, CancellationToken cancellationToken)
        {
            var modality = _mapper.Map<Domain.Administractive.Modality.Limits.Modality>(request);

            _modalityRepository.Create(modality);

            return await CustomResponse(_unitOfWork);
        }
    }
}
