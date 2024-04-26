using AutoMapper;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Interfaces;
using MinhaEscola.Service.Application.UseCases.Modality.Responses;
using MinhaEscola.Service.Domain.Administractive.Modality.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Modality.Queries
{
    public class ModalityQueries : BaseQuery, IModalityQueries
    {
        private readonly IModalityRepository _modalityRepository;
        private readonly IMapper _mapper;

        public ModalityQueries(IModalityRepository modalityRepository, IMapper mapper)
        {
            _modalityRepository= modalityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<ModalityResponse>>(await _modalityRepository.GetAll()));
        }
    }
}
