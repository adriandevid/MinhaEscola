using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.School.Commands
{
    public class UpdateSchoolCommandHandler : CommandHandler, IRequestHandler<UpdateSchoolRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly ISchoolRepository _schoolRepository;

        public UpdateSchoolCommandHandler(IUnitOfWorkResource unitOfWorkResource, ISchoolRepository schoolRepository)
        {
            _unitOfWork = unitOfWorkResource;
            _schoolRepository = schoolRepository;
        }

        public async Task<ApiResponse> Handle(UpdateSchoolRequest request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.GetSchoolById(request.Id);
            
            school.Update(request.Name, request.NameAbbreviated, request.CNPJ);

            _schoolRepository.Update(school);

            return await CustomResponse(_unitOfWork);
        }
    }
}
