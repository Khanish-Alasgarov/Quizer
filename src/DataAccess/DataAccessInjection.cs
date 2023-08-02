using DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbContext, Context>();

        }
    }
}
