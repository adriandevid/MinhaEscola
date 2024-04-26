using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.ValueObject;
using Person = MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits.PhysicalPerson;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Commands
{
    public class AppendDocumentToPhysicalPersonCommandHandler : CommandHandler, IRequestHandler<AppendDocumentToPhysicalPersonRequest, ApiResponse>
    {
        private readonly IPhysicalPersonRepository _physicalPersonRepository;
        private readonly IUnitOfWorkResource _unitOfWork;
        public AppendDocumentToPhysicalPersonCommandHandler(IPhysicalPersonRepository physicalPersonRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _physicalPersonRepository= physicalPersonRepository;
            _unitOfWork= unitOfWorkResource;
        }
        public async Task<ApiResponse> Handle(AppendDocumentToPhysicalPersonRequest request, CancellationToken cancellationToken)
        {
            Person? physicalPerson = await _physicalPersonRepository.GetElementById(request.PhysicalPersonId);

            physicalPerson!.AppendDocumentation(new Documentation(request.AttachmentId, (TypeDocument)request.TypeDocumentationId));

            return await CustomResponse(_unitOfWork);
        }
    }
}
