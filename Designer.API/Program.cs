using Designer.BLL.Configurations;
using Designer.BLL.DependencyInjection;
using Designer.DAL.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;

namespace Designer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options
                => options.AddDefaultPolicy(b =>
                {
                    b.AllowAnyHeader();
                    b.AllowAnyMethod();
                    b.AllowAnyOrigin();
                }));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<SqlConnection>(pc => new SqlConnection(builder.Configuration.GetConnectionString("default")));

            // BLL and DAL Dependencies Injections
            JwtConfiguration jwtConfig = builder.Configuration.GetSection("JwtSettings").Get<JwtConfiguration>();
            builder.Services.AddRepositories();
            builder.Services.AddBusinessServices(jwtConfig);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtConfig.ValidateIssuer,
                    ValidateAudience = jwtConfig.ValidateAudience,
                    ValidateLifetime = jwtConfig.ValidateLifeTime,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Signature)),
                }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}





