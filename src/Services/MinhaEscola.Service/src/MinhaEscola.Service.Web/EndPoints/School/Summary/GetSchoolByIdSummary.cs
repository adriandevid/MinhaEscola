﻿using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class GetSchoolByIdSummary : Summary<GetSchoolByIdEndPoint>
    {
        public GetSchoolByIdSummary()
        {
            Summary = "Create a new school";
            Description = "This school what have aproved";
            ExampleRequest = new ApiResponse();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
