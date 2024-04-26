

using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Address.Interfaces;
using MinhaEscola.Service.Application.UseCases.Address.Responses;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Domain.Core.Address.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Address.Queries
{
    public class AddressQueries : BaseQuery, IAddressQueries
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressQueries(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository= addressRepository;
            _mapper= mapper;
        }

        public async Task<ApiResponse> GetById(long id)
        {
            return CustomResponse(_mapper.Map<AddressResponse>(await _addressRepository.GetElementById(id)));
        }
    }
}
