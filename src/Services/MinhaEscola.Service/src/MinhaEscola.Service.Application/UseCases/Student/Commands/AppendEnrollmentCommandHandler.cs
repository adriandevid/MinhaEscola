using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Limits;

namespace MinhaEscola.Service.Application.UseCases.Student.Commands
{
    public class AppendEnrollmentCommandHandler : CommandHandler, IRequestHandler<AppendEnrollmentRequest, ApiResponse>
    {
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly IStudentRepository _studentRepository;
        public AppendEnrollmentCommandHandler(IUnitOfWorkResource unitOfWorkResource, IStudentRepository studentRepository)
        {
            _unitOfWork = unitOfWorkResource;
            _studentRepository = studentRepository;
        }

        public async Task<ApiResponse> Handle(AppendEnrollmentRequest request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetElementById(request.StudentId);

            student.AssignEnrolleee(new Enrollment(request.ClassId, request.StudentId, request.Year, request.DateEnrollee, request.Active));

            return await CustomResponse(_unitOfWork);
        }
    }
}
