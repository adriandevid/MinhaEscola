using AutoMapper;
using LamarCodeGeneration.Frames;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Interfaces;
using MinhaEscola.Service.Application.UseCases.Class.Responses;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Specifications.Selection;
using MinhaEscola.Service.Infrastructure.Commom;

namespace MinhaEscola.Service.Application.UseCases.Class.Queries
{
    public class ClassQueries : BaseQuery, IClassQueries
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextRequestInformations;

        public ClassQueries(IClassRepository classRepository, IMapper mapper, IHttpContextAccessor contextRequestInformations)
        {
            _classRepository = classRepository;
            _mapper = mapper;
            _contextRequestInformations = contextRequestInformations;
        }

        public async Task<ApiResponse> GetById(long id)
        {
            return CustomResponse(_mapper.Map<ClassesResponse>(await _classRepository.GetElementById(id)));
        }

        public async Task<ApiResponse> GetClassesOfSchoolByUserReference()
        {
            return CustomResponse(_mapper.Map<List<ClassesResponse>>(await _classRepository.ApplySpecification(new GetClassesOfSchoolByUserReferenceSpecification(_contextRequestInformations.GetUserId()))));
        }
    }
}
