using Microsoft.EntityFrameworkCore;
using MusinfoBL.Services.Interface;
using MusinfoBL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CommonDataAccess.Repository;
using CommonDataAccess.Repository.Interfaces;
using CommonDataAccess.UnitOfWork.Interface;
using CommonDataAccess.UnitOfWork;
using MusinfoDB;
using MusinfoDB.Finders;
using MusinfoDB.Finders.Interface;
using MusinfoDB.Models;
using MusinfoBL;

namespace MusinfoWebAPI
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddControllers();

            services.AddScoped<DbContext, MusinfoDBContext>();
            services.AddDbContext<MusinfoDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MSSQL")));

            services.AddScoped<ICommonFinder<User>, CommonFinder<User>>();
            services.AddScoped<ICommonFinder<Role>, CommonFinder<Role>>();

            services.AddScoped<IRepository<User>, Repository<User>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IService<User>, Service<User>>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
