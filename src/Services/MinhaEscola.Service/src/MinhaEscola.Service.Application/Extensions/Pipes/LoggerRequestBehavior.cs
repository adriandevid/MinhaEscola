using MediatR;
using Microsoft.Extensions.Logging;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MinhaEscola.Service.Application.Extensions.Pipes
{
    public class LoggerRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Request
            Console.WriteLine($"Handling {typeof(TRequest).Name}");
            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                Console.WriteLine("{Property} : {@Value}", prop.Name, propValue);
            }
            var response = await next();
            //Response
            Console.WriteLine($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
