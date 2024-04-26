using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Discipline.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Commands
{
    public class UpdateDisciplineCommandHandler : CommandHandler, IRequestHandler<UpdateDisciplineRequest, ApiResponse>
    {
        private readonly IDisciplineRepository _repository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public UpdateDisciplineCommandHandler(IDisciplineRepository disciplineRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _repository= disciplineRepository;
            _unitOfWork= unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(UpdateDisciplineRequest request, CancellationToken cancellationToken)
        {
            var discipline = await _repository.GetElementById(request.Id);

            discipline!.Update(request.Name);

            return await CustomResponse(_unitOfWork);
        }
    }
}
