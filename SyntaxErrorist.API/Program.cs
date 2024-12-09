using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SyntaxErrorist.Infrastructure.Context;
using SyntaxErrorist.Shared.Models;
using SyntaxErrorist.Services.Services;
using SyntaxErrorist.Core.IService;

namespace SyntaxErrorist.Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            ConfigureServices(builder.Services, builder.Configuration);






            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddControllers()
                .AddControllersAsServices();

            services.AddEndpointsApiExplorer();
            //ConfigureSwagger(services);
            ConfigureIdentity(services);
            //ConfigureJwtAuthentication(services, configuration);
            ConfigureDatabase(services, configuration);
            //RegisterApplicationServices(services);

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();

        }

        static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

        }
    }
}
