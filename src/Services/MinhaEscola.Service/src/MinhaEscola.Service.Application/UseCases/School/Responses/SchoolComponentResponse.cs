using MinhaEscola.Service.Application.UseCases.Component.Responses;

namespace MinhaEscola.Service.Application.UseCases.School.Responses
{
    public class SchoolComponentResponse
    {
        public long Id { get; set; }
        public long SchoolId { get; set; }
        public long ComponentId { get; set; }

        public ComponentResponse Component { get; set; }
    }
}
