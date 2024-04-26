using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Commands
{
    public class CreateKnowledgeAreaCommandHandler : CommandHandler, IRequestHandler<CreateKnowledgeAreaRequest, ApiResponse>
    {
        private readonly IKnowledgeAreaRepository _repository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public CreateKnowledgeAreaCommandHandler(IKnowledgeAreaRepository repository, IUnitOfWorkResource unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(CreateKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var knowledgeArea = new Domain.Administractive.KnowledgeArea.Limits.KnowledgeArea(request.Name, request.Description);
            
            _repository.Create(knowledgeArea);

            return await CustomResponse(_unitOfWork);
        }
    }
}
