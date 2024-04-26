using MinhaEscola.Service.Application.UseCases.Component.Responses;

namespace MinhaEscola.Service.Application.UseCases.Class.Responses
{
    public class ClassesResponse
    {
        public ClassesResponse() { }

        public long Id { get; set; }
        public long AmountStudent { get; set; }
        public bool Active { get; set; }
        public string Denomination { get; set; }
        public long ComponentId { get; set; }
        public long Year { get; set; }
        public long SchoolId { get; set; }
        public ComponentResponse Component { get; set; }
    }
}
