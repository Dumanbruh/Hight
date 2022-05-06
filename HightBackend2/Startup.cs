using HightBackend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using HightBackend.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;

namespace HightBackend
{
    public class Startup
    {

        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddCors(options => 
               options.AddDefaultPolicy(
                   builder => builder.AllowAnyOrigin()
                   ));

                
            services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = null
                );

            services.AddScoped<IUserService, UserService>();

            services.AddHttpContextAccessor();


            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization", 
                    Type = SecuritySchemeType.ApiKey
                });


                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });


            services.AddDbContext<AppDbContext>(options =>  
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
/*           .AddCookie(options =>
            {
                options.LoginPath = "/account/google-login";
            })
            .AddGoogle(options =>
            {
                options.ClientId = "828276514199-6h0qvjar596jsket42dirfvu5glmiulr.apps.googleusercontent.com";
                options.ClientSecret = "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";
            })*/
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(Configuration.GetSection("AppSettings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddApplicationInsightsTelemetry();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HightBackend v1"));
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
