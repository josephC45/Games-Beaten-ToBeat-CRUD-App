using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;

namespace HobbyToFinishApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            //Dependency injection for add game Interface and service and game repository
            builder.Services.AddScoped<IAddGamesService, AddGamesService>();
            builder.Services.AddScoped<IGetGamesService, GetGamesService>();
            builder.Services.AddScoped<IUpdateGamesService,UpdateGamesService>();
            builder.Services.AddScoped<IDeleteGamesService, DeleteGamesService>();
            builder.Services.AddScoped<IGamesRepository, GamesRepository>();

            //Add Db context reference when needed
            //Initial connection of the db
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
            });
            var app = builder.Build();
            app.UseHttpLogging();

            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.Run();

        }
    }
}
