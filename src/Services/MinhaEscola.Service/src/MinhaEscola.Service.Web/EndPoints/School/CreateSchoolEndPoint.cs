﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpPost("/school")]
    //[Authorize(Roles = "Client School Adm, Admin")]
    [Authorize]
    public class CreateSchoolEndPoint : Endpoint<CreateSchoolRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public CreateSchoolEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(CreateSchoolRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
