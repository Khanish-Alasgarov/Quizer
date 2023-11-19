using Core.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Api.PipelineElements
{
    internal class ValidatorInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                var errors = result.Errors.GroupBy(m => m.PropertyName)
                     .ToDictionary(k => k.Key, v => v.Select(x => x.ErrorMessage).ToArray());
                throw new BadRequestException("Göndərilən model tələblərə cavab vermir!", errors);
            }
            return result;
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }
    }
    internal static class ValidatorInterceptorException
    {
        internal static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidatorInterceptor, ValidatorInterceptor>();
            return services;

        }
    }
}
