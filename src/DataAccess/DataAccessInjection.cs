using Core.Repositories.Special;
using DataAccess.Persistence;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, Context>();
            #region Repository Injection
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionSetRepository, QuestionSetRepository>();
            services.AddScoped<ISessionContentRepository, SessionContentRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            #endregion
            return services;
        }
        public static IApplicationBuilder UseDataAccess(this IApplicationBuilder app)
        {
            app.UseAutoMigration();
            return app;
        }
    }
}
