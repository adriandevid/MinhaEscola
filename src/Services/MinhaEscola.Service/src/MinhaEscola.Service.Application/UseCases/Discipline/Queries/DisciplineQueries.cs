using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Interfaces;
using MinhaEscola.Service.Application.UseCases.Discipline.Responses;
using MinhaEscola.Service.Domain.Administractive.Discipline.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Queries
{
    public class DisciplineQueries : BaseQuery, IDisciplineQueries
    {
        private readonly IDisciplineRepository _repository;
        private readonly IMapper _mapper;

        public DisciplineQueries(IDisciplineRepository disciplineRepository, IMapper mapper)
        {
            _repository= disciplineRepository;
            _mapper= mapper;
        }

        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<DisciplineResponse>>(await _repository.GetAll()));
        }
    }
}
