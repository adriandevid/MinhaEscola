

namespace MinhaEscola.Service.Application.UseCases.Address.Responses
{
    public class AddressResponse
    {
        public string Street { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public long ZoneId { get; set; }
    }
}
