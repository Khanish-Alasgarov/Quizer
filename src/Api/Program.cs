
using Api.PipelineElements;
using Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers().AddNewtonsoftJson(cfg =>
            {
                cfg.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                cfg.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        ProcessDictionaryKeys = true,
                    },
                    
                };
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddBusinessLogic(builder.Configuration);

            builder.Services.AddValidatorsFromAssemblyContaining<IValidatorReferance>(includeInternalTypes: true);

            builder.Services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
            });

            builder.Services.AddFluentValidation();

            builder.Services.AddSwaggerGen(cfg =>
            {
                cfg.EnableAnnotations();
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title="Quizer",
                    Description ="Quizer NTier arc",
                    TermsOfService= new Uri("https://github.com/KhanishAlasgarov?tab=repositories"), // Bu apini nece istifadə edə bilərik onunla əlaqəli
                                                                     // qaydaların yer aldığı linki bura qeyd etməliyik
                    Contact = new OpenApiContact
                    {
                        Name = "Khanish Alasgarov",
                        Email= "aleskeroov@gmail.com",
                        Url = new Uri("https://github.com/KhanishAlasgarov?tab=repositories"),
                        
                    },

                    License = new OpenApiLicense()
                    {
                        Name="Document",
                        Url = new Uri("https://github.com/KhanishAlasgarov")
                    }
                });
            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(cfg =>
                {
                    cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "Quizer");
                });
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