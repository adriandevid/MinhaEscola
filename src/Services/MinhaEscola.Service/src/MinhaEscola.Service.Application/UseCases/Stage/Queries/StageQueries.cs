using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Interfaces;
using MinhaEscola.Service.Application.UseCases.Stage.Responses;
using MinhaEscola.Service.Domain.Administractive.Stage.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Stage.Queries
{
    public class StageQueries : BaseQuery, IStageQueries
    {
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;

        public StageQueries(IStageRepository stageRepository, IMapper mapper) {
            _stageRepository= stageRepository;
            _mapper= mapper;
        }

        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<StageResponse>>(await _stageRepository.GetAll()));
        }
    }
}
