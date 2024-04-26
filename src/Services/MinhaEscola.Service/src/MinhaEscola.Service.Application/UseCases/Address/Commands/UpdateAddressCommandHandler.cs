using MediatR;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Core.Address.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Address.Commands
{
    public class UpdateAddressCommandHandler : CommandHandler, IRequestHandler<UpdateAddressRequest, ApiResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWorkResource _unitOfWork;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IUnitOfWorkResource unitOfWorkResource)
        {
            _addressRepository= addressRepository;
            _unitOfWork= unitOfWorkResource;
        }

        public async Task<ApiResponse> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            Domain.Core.Address.Limits.Address? address = await _addressRepository.GetElementById(request.Id);
            
            address!.Update(request.Street, request.CEP, request.Neighborhood, request.ZoneId);

            return await CustomResponse(_unitOfWork);
        }
    }
}
