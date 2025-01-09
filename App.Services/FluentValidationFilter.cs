using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Services;

public class FluentValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
                     
            var errors = context.ModelState.Values.SelectMany(x=>x.Errors.Select(p=>p.ErrorMessage)).ToList();
            var result = ServiceResult.FailNoContent(errors);
            context.Result = new BadRequestObjectResult(result);
        }
        else
        {
            await next();
        }
    }
}