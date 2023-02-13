using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PraticaLogin.Service;
using UsuariosLogin.Data;

using UsuariosLogin.Services;

namespace UsuariosLogin
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<UserDbContext>(opt => opt.UseMySQL(Configuration.GetConnectionString("UsuarioConnection")));

            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
             opt => opt.SignIn.RequireConfirmedEmail = true)
             .AddEntityFrameworkStores<UserDbContext>()
              .AddDefaultTokenProviders();

            services.AddScoped<CadastroService,CadastroService>();
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<LoginService, LoginService>();
      
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }

    }
}
