using FluentValidation.Results;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Base.Query
{
    public class BaseQuery
    {
        public ApiResponse CustomResponse(object response)
        {
            return new ApiResponse
            {
                Data = response,
                ValidationResult = new FluentValidation.Results.ValidationResult()
            };
        }
    }
}
