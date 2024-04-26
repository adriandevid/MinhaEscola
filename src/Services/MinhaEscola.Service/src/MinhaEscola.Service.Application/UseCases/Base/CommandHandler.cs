using FluentValidation.Results;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Domain.Base.Interfaces;

namespace MinhaEscola.Service.Application.UseCases.Base
{
    public class CommandHandler
    {
        private readonly List<ValidationFailure> errors = new List<ValidationFailure>();
        public CommandHandler() { }

        public async Task<ApiResponse> CustomResponse(IUnitOfWorkResource unitOfWork) {
            try {
                if (!await unitOfWork.Save())
                {
                    AppendError("Inner exception in execute procedure.");
                }

                return new ApiResponse()
                {
                    Data = null,
                    ValidationResult = new ValidationResult(errors)
                };
            } 
            catch (Exception ex)
            {
                AppendError("Inner exception in execute procedure.");
                return new ApiResponse()
                {
                    Data = null,
                    ValidationResult = new ValidationResult(errors)
                };
            }
        }

        public void AppendError(string messageError) {
            errors.Add(new ValidationFailure("", messageError));
        }
    }
}
