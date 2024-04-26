using AutoMapper;
using Microsoft.AspNetCore.Http;
using MinhaEscola.Service.Application.UseCases.Base.Query;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;
using MinhaEscola.Service.Application.UseCases.School.Responses;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Infrastructure.Commom;

namespace MinhaEscola.Service.Application.UseCases.School.Queries
{
    public class SchoolQueries : BaseQuery, ISchoolQueries
    {
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IHttpContextAccessor _contextRequestInformations;

        public SchoolQueries(ISchoolRepository repository, IMapper mapper, IHttpContextAccessor contextRequestInformations)
        {
            _mapper = mapper;
            _schoolRepository = repository;
            _contextRequestInformations = contextRequestInformations;
        }


        public async Task<ApiResponse> GetAll()
        {
            return CustomResponse(_mapper.Map<List<SchoolResponse>>(await _schoolRepository.GetAll()));
        }

        public async Task<ApiResponse> GetByUserReference()
        {
            return CustomResponse(_mapper.Map<SchoolResponse>(await _schoolRepository.GetSchoolByUserReference(_contextRequestInformations.GetUserId())));
        }

        public async Task<ApiResponse> GetComponentsOfSchoolById(long schoolId)
        {
            return CustomResponse(_mapper.Map<List<SchoolComponentResponse>>(await _schoolRepository.GetComponentsOfSchool(schoolId)));
        }

        public async Task<ApiResponse> GetComponentsOfSchoolByUserReference()
        {
            return CustomResponse(_mapper.Map<List<SchoolComponentResponse>>(await _schoolRepository.GetComponentsOfSchoolByUserReference(_contextRequestInformations.GetUserId())));
        }

        public async Task<ApiResponse> GetDisciplineComponent(long schoolId, long id)
        {
            return CustomResponse(_mapper.Map<SchoolDisciplineResponse>(await _schoolRepository.GetDisciplineComponent(schoolId, id)));
        }

        public async Task<ApiResponse> GetDisciplinesOfSchoolById(long schoolId)
        {
            return CustomResponse(_mapper.Map<List<SchoolDisciplineResponse>>(await _schoolRepository.GetDisciplinesOfSchool(schoolId)));
        }

        public async Task<ApiResponse> GetSchoolById(long id)
        {
            return CustomResponse(_mapper.Map<SchoolResponse>(await _schoolRepository.GetSchoolById(id)));
        }
    }
}
