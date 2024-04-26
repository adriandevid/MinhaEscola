using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Commands
{
    public class UpdateKnowledgeAreaCommandHandler : CommandHandler, IRequestHandler<UpdateKnowledgeAreaRequest, ApiResponse>
    {
        private readonly IKnowledgeAreaRepository _repository;
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateKnowledgeAreaCommandHandler(IKnowledgeAreaRepository repository, IUnitOfWorkResource unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var knowledgeArea = await _repository.GetElementById(request.Id);
           
            _mapper.Map(request, knowledgeArea);

            _repository.Update(knowledgeArea);

            return await CustomResponse(_unitOfWork);
        }
    }
}
