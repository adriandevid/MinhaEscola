using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Interfaces;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Responses;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Queries
{
    public class KnowledgeAreaQueries : BaseQuery, IKnowledgeAreaQueries
    {
        private readonly IKnowledgeAreaRepository _repository;
        private readonly IMapper _mapper;

        public KnowledgeAreaQueries(IKnowledgeAreaRepository knowledgeAreaRepository, IMapper mapper)
        {
            _repository= knowledgeAreaRepository;
            _mapper= mapper;
        }

        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<KnowledgeAreaResponse>>(await _repository.GetAll()));
        }
    }
}
