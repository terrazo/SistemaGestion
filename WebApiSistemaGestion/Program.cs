using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.service;

namespace WebApiSistemaGestion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<ProductoVendidoService>();
            builder.Services.AddScoped<VentaService>();

            builder.Services.AddScoped<UsuarioMapper>();
            builder.Services.AddScoped<ProductoMapper>();
            builder.Services.AddScoped<ProductoVendidoMapper>();
            builder.Services.AddScoped<VentaMapper>();



            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin(); 
                    policy.AllowAnyHeader();
                });
            });

            /*
            builder.Services.AddExceptionHandler((options)=>
            {
                options.ExceptionHandler = new RequestDelegate(async(context))
            })
            */

            builder.Services.AddDbContext<CoderContext>(options =>
            {

                //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=coderhouse;Trusted_Connection=True;");
                options.UseSqlServer("Server=.; Database=coderhouse; Trusted_Connection=True;");

            });

            //
            /*
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            */
            //


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}