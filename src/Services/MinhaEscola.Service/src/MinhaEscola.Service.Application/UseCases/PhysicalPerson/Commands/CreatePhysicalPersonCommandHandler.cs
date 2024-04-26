using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using Person = MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits.PhysicalPerson;
using AddressEntity = MinhaEscola.Service.Domain.Core.Address.Limits.Address;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Interfaces;
using MinhaEscola.Service.Domain.Base.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Commands
{
    public class CreatePhysicalPersonCommandHandler : CommandHandler, IRequestHandler<CreatePhysicalPersonRequest, ApiResponse>
    {
        private readonly IPhysicalPersonRepository _physicalPersonRepository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public CreatePhysicalPersonCommandHandler(IPhysicalPersonRepository physicalPersonRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _physicalPersonRepository = physicalPersonRepository;
            _unitOfWork = unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(CreatePhysicalPersonRequest request, CancellationToken cancellationToken)
        {
           AddressEntity address = new AddressEntity(request.Address.Street, request.Address.CEP, request.Address.Neighborhood, request.Address.ZoneId);

           Person physicalPerson = new Person(
               request.Name, 
               request.Year, 
               request.RegisterOfPhysicalPerson,
               address, 
               request.SexId, 
               request.ColorId, 
               request.RegisterGeneral, 
               request.NationalityId);

            _physicalPersonRepository.Create(physicalPerson);

            return await CustomResponse(_unitOfWork);
        }
    }
}
