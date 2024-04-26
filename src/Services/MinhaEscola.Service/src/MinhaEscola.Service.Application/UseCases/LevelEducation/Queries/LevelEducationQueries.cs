using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Interfaces;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Responses;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Queries
{
    public class LevelEducationQueries : BaseQuery, ILevelEducationQueries
    {
        private readonly ILevelEducationRepository _levelEducationRepository;
        private readonly IMapper _mapper;

        public LevelEducationQueries(ILevelEducationRepository levelEducationRepository, IMapper mapper) { 
            _levelEducationRepository= levelEducationRepository;
            _mapper= mapper;
        }
        
        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<LevelEducationResponse>>(await _levelEducationRepository.GetAll()));
        }
    }
}
