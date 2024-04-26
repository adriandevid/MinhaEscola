using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Interfaces;
using MinhaEscola.Service.Application.UseCases.Component.Responses;
using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Component.Queries
{
    public class ComponentQueries : BaseQuery, IComponentQueries
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IMapper _mapper;

        public ComponentQueries(IComponentRepository componentRepository, IMapper mapper)
        {
            _componentRepository= componentRepository;
            _mapper= mapper;
        }


        public async Task<ApiResponse> GetAllDenominations()
        {
            return CustomResponse(_mapper.Map<List<DenominationResponse>>(await _componentRepository.GetAllDenominations()));
        }

        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<ComponentResponse>>(await _componentRepository.GetAll()));
        }
    }
}
