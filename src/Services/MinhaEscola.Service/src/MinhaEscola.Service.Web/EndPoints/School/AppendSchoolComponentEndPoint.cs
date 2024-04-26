﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpPost("/school/{schoolId}/component")]
    [Authorize]
    public class AppendSchoolComponentEndPoint : Endpoint<AppendSchoolComponentRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public AppendSchoolComponentEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(AppendSchoolComponentRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
