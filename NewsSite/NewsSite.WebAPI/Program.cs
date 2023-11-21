using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsSite.DAL.Context;
using NewsSite.UI.Extensions;

namespace NewsSite.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<OnlineNewsContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("NewsDatabaseConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<OnlineNewsContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthenticationWithJwt(builder.Configuration);

            builder.Services.RegisterRepositories();
            builder.Services.RegisterAutoMapper();
            builder.Services.AddCustomServices();

            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}