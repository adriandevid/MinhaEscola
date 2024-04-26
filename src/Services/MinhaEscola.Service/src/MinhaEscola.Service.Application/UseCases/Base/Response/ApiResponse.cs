using FluentValidation.Results;

namespace MinhaEscola.Service.Application.UseCases.Base.Response
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
