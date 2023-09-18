using Core.Attributes;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Api.PipelineElements
{
    internal class DbTransactionMiddleware
    {
        private RequestDelegate next { get; }

        public DbTransactionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DbContext db)
        {
            if (context.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            {
                await next(context);
                return;
            }

            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<TransactionAttribute>();

            if (attribute == null)
            {
                await next(context);
                return;
            }

            IDbContextTransaction transaction = null;

            try
            {
                transaction = db.Database.BeginTransaction();
                await next(context);
                await transaction.CommitAsync();

            }
            catch
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                }
                throw;
            }
            finally 
            {
                transaction?.Dispose(); 
                //GC.Collect();
            }


        }
    }

    internal static class DbTransactionMiddlewareExtension
    {
        internal static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app)
        {
            app.UseMiddleware<DbTransactionMiddleware>();
            return app;
        }
    }
}
