
using Api.PipelineElements;
using Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddBusinessLogic(builder.Configuration);

            builder.Services.AddValidatorsFromAssemblyContaining<IValidatorReferance>(includeInternalTypes: true);

            builder.Services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
            });

            builder.Services.AddFluentValidation();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            //if (!app.Environment.IsDevelopment())
            //{
            //    app.AddGlobalErrorhandling();
            //}
            app.UseGlobalErrorhandling();

            app.UseDbTransaction();

            app.UseBusinessLogic();

            app.Run();
        }
    }
}