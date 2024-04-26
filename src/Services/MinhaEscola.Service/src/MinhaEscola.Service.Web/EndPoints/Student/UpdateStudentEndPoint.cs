using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Student
{
    [HttpPut("/student/")]
    [Authorize]
    public class UpdateStudentEndPoint : Endpoint<UpdateStudentRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public UpdateStudentEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateStudentRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
