using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Services.ExceptionHandlers;

public class CriticalExceptionHandler(ILogger<CriticalExceptionHandler> logger) :IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is CriticalException)
        {
            Console.WriteLine("sms sent to admin");
        }
         
        //business logic to handle exception
        return await ValueTask.FromResult(false);
        
    }
}