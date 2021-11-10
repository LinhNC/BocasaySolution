using Application.Configurations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Add Fluent Validations
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        internal static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppConfiguration>());
            return builder;
        }
    }
}
