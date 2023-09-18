

using Application.Services;
using Core.Services;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class BusinessLogicInjection
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
    {
        #region Register Services
        services.AddScoped<IQuestionSetService, QuestionSetService>();
        services.AddScoped<IQuestionService, QuestionService>();
        #endregion
        services.AddDataAccess(configuration);
        return services;
    }
    public static IApplicationBuilder UseBusinessLogic(this IApplicationBuilder app)
    {
        //app.UseDataAccess();
        //return app;
        return app.UseDataAccess();
    }
}
