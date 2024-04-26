
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests
{
    public class UpdatePhysicalPersonRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? RegisterOfPhysicalPerson { get; set; }
        public long SexId { get; set; }
        public long ColorId { get; set; }
        public string? RegisterGeneral { get; set; }
        public long NationalityId { get; set; }
    }
}
