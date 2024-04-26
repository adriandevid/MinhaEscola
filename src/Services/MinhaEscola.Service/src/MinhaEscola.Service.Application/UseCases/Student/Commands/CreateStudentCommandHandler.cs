using AutoMapper;
using Marten.Services;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Student.Commands
{
    public class CreateStudentCommandHandler : CommandHandler, IRequestHandler<CreateStudentRequest, ApiResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWorkResource unitOfWork, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            var student = new Domain.Academic.Student.Limits.Student(request.SchoolId, request.INEP, request.UseTransport, request.PhysicalPersonId, request.UserReference);

            _studentRepository.Create(student);
            
            return await CustomResponse(_unitOfWork);
        }
    }
}
