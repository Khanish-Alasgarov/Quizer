using Core.Exceptions;
using Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Text.Json;

namespace Api.PipelineElements;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            ApiResponse response = null;
            switch (ex)
            {
                case NotFoundException:
                    response = ApiResponse.Fail(ex.Message, HttpStatusCode.NotFound);
                    break;
                case UnhandledException:

                    break;
                case BadRequestException br:
                    response = ApiResponse.Fail(br.Errors, ex.Message, HttpStatusCode.BadRequest);
                    break;
                default:
                    response = ApiResponse.Fail("Xəta baş verdi! Biraz sonra yeniden yoxlayın!!!", HttpStatusCode.InternalServerError);
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }));


        }
    }
}

internal static class GlobalErrorHandlingMilldewareExtension
{
    internal static IApplicationBuilder UseGlobalErrorhandling(this IApplicationBuilder builder)
    {

        builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        return builder;
    }
}