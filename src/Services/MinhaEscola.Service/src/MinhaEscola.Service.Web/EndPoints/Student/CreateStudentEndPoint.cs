using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Student
{

    [HttpPost("/student/")]
    [Authorize]
    public class CreateStudentEndPoint : Endpoint<CreateStudentRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public CreateStudentEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(CreateStudentRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
