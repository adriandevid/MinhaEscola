using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Discipline
{
    [HttpGet("/discipline/")]
    [Authorize]
    public class GetAllDisciplineEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IDisciplineQueries _queries;

        public GetAllDisciplineEndPoint(IDisciplineQueries disciplineQueries)
        {
            _queries= disciplineQueries;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(await _queries.GetAll());
        }
    }
}
