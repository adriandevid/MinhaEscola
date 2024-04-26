using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Discipline.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Commands
{
    public class CreateDisciplineCommandHandler : CommandHandler, IRequestHandler<CreateDisciplineRequest, ApiResponse>
    {
        private readonly IDisciplineRepository _repository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public CreateDisciplineCommandHandler(IUnitOfWorkResource unitOfWorkResource, IDisciplineRepository disciplineRepository) {
            _repository = disciplineRepository;
            _unitOfWork = unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(CreateDisciplineRequest request, CancellationToken cancellationToken)
        {
            var discipline = new Domain.Administractive.Discipline.Limits.Discipline(request.Name, request.KnowledgeAreaId);
            
            _repository.Create(discipline);

            return await CustomResponse(_unitOfWork);
        }
    }
}
