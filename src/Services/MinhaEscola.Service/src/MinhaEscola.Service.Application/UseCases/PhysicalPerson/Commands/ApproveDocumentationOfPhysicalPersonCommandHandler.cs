using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Commands
{
    public class ApproveDocumentationOfPhysicalPersonCommandHandler : CommandHandler, IRequestHandler<ApproveDocumentationOfPhysicalPersonRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWorkResource;
        private readonly IPhysicalPersonRepository _physicalPersonRepository;

        public ApproveDocumentationOfPhysicalPersonCommandHandler(IUnitOfWorkResource unitOfWorkResource, IPhysicalPersonRepository physicalPersonRepository)
        {
            _physicalPersonRepository= physicalPersonRepository;
            _unitOfWorkResource= unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(ApproveDocumentationOfPhysicalPersonRequest request, CancellationToken cancellationToken)
        {
            var physicalPerson = await _physicalPersonRepository.GetElementById(request.Id);
            physicalPerson!.DocumentationIsValid(request.DocumentId);

            return await CustomResponse(_unitOfWorkResource);
        }
    }
}
