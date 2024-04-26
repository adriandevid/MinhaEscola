using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Class.Requests
{
    public class CreateClassRequest : IRequest<ApiResponse>
    {
        public long AmountStudent { get; set; }
        public bool Active { get; set; }
        public string Denomination { get; set; }
        public long ComponentId { get; set; }
        public long Year { get; set; }
        public long SchoolId { get; set; }
    }
}
