using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Base.Request
{
    public class BaseRequest
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
