using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Student
{
    [HttpPost("student/{studentId}/enrollment")]
    [Authorize]
    public class AppendEnrollmentEndPoint : Endpoint<AppendEnrollmentRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public AppendEnrollmentEndPoint(IMediator mediator) { 
            _mediator = mediator;
        }

        public override async Task HandleAsync(AppendEnrollmentRequest req, CancellationToken cancellationToken) 
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
