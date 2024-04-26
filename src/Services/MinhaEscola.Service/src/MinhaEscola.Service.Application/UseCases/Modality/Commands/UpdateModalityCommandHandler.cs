using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Modality.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Modality.Commands
{
    public class UpdateModalityCommandHandler : CommandHandler, IRequestHandler<UpdateModalityRequest, ApiResponse>
    {
        private readonly IModalityRepository _modalityRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkResource _unitOfWork;

        public UpdateModalityCommandHandler(IModalityRepository modalityRepository, IMapper mapper, IUnitOfWorkResource unitOfWorkResource)
        {
            _modalityRepository = modalityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWorkResource;
        }


        public async Task<ApiResponse> Handle(UpdateModalityRequest request, CancellationToken cancellationToken)
        {
            var modalityDestination = await _modalityRepository.GetElementById(request.Id);

            var modalityModify = _mapper.Map(request, modalityDestination);

            _modalityRepository.Update(modalityModify);

            return await CustomResponse(_unitOfWork);
        }
    }
}
