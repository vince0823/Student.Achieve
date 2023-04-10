using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Fabricdot.Domain.SharedKernel;

namespace Student.Achieve.WebApi.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = string.Join(",", context.ModelState
                                .SelectMany(ms => ms.Value.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToArray());

                if (messages.Length > 0)
                {
                    throw new DomainException(messages,500);
                }

            }
        }
    }
}
