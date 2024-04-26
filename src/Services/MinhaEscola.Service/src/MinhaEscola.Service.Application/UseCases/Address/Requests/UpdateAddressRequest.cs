using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Address.Requests
{
    public class UpdateAddressRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public long ZoneId { get; set; }
    }
}
