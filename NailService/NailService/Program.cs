using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using NailService.Data;
using NailService.Services;
using NailService.Services.Impl;
using NLog.Web;

namespace NailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure logging service

            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All | HttpLoggingFields.RequestQuery;
                logging.RequestBodyLogLimit = 1024;
                logging.ResponseBodyLogLimit = 1024;
                logging.RequestHeaders.Add("Authorization");
                logging.RequestHeaders.Add("X-Real-IP");
                logging.RequestHeaders.Add("X-Forwarded-For");
            });

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            }).UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = true });

            #endregion

            #region Configure EF DBContext Service (CardStorageService Database)

            builder.Services.AddDbContext<NailSeviceDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["Settings:DatabaseOptions:ConnectionString"]);
            });

            #endregion

            #region Configure Repository Services

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ITypeOfWorkRepository, TypeOfWorkRepository>();
            builder.Services.AddScoped<IAppountmentRepository, AppountmentRepository>();

            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseHttpLogging();

            app.MapControllers();

            app.Run();
        }
    }
}