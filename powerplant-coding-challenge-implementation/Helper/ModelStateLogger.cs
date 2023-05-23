using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace powerplant_coding_challenge_implementation.Logging
{
    public static class ModelStateLogger
    {
        public static void LogErrors(ModelStateDictionary modelState, ILogger logger)
        {
            IEnumerable<string> errorMessages = modelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            foreach (string errorMessage in errorMessages)
            {
                logger.LogWarning(errorMessage);
            }
        }
    }
}