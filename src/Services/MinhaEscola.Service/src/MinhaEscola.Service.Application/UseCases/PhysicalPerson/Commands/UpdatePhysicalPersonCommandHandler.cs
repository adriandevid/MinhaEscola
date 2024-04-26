using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Interfaces;
using Person = MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits.PhysicalPerson;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Commands
{
    public class UpdatePhysicalPersonCommandHandler : CommandHandler, IRequestHandler<UpdatePhysicalPersonRequest, ApiResponse>
    {

        private readonly IPhysicalPersonRepository _physicalPersonRepository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public UpdatePhysicalPersonCommandHandler(IPhysicalPersonRepository physicalPersonRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _physicalPersonRepository = physicalPersonRepository;
            _unitOfWork = unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(UpdatePhysicalPersonRequest request, CancellationToken cancellationToken)
        {
            Person? physicalPerson = await _physicalPersonRepository.GetElementById(request.Id);

            physicalPerson?.Update(request.Name, request.Year, request.RegisterOfPhysicalPerson, request.SexId, request.ColorId, request.RegisterGeneral, request.NationalityId);

            _physicalPersonRepository.Update(physicalPerson!);

            return await CustomResponse(_unitOfWork);
        }
    }
}
