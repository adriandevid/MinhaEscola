using AutoMapper;
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Student.Commands
{
    public class UpdateStudentCommandHandler : CommandHandler, IRequestHandler<UpdateStudentRequest, ApiResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWorkResource _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWorkResource unitOfWork, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            Domain.Academic.Student.Limits.Student student = await _studentRepository.GetById(request.Id);

            _studentRepository.Update(_mapper.Map(request, student));

            return await CustomResponse(_unitOfWork);
        }
    }
}
