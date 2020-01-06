using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Calendar.Server.Models;

namespace Calendar.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => { options.RequireHttpsMetadata = false; options.TokenValidationParameters = new TokenValidationParameters { ValidateIssuer = true, ValidIssuer = AuthenticationOptions.ISSUER, ValidateAudience = true, ValidAudience = AuthenticationOptions.AUDIENCE, ValidateLifetime = true, IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(), ValidateIssuerSigningKey = true }; });
            services.AddDbContext<CalendarContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseMvc();
        }
    }
}