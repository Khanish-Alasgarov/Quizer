using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    internal static class AutoMigrateDatabase
    {
        public static IApplicationBuilder UseAutoMigration(this IApplicationBuilder app)
        {
            using (var scope= app.ApplicationServices.CreateScope())
            {
                var db =scope.ServiceProvider.GetRequiredService<DbContext>();
                db?.Database.Migrate();
                
            }
            return app;
        }
    }
}
