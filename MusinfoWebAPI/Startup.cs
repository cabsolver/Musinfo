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
            services.AddScoped<ICommonFinder<Artist>, CommonFinder<Artist>>();
            services.AddScoped<ICommonFinder<Genre>, CommonFinder<Genre>>();
            services.AddScoped<ICommonFinder<Song>, CommonFinder<Song>>();
            services.AddScoped<ICommonFinder<Release>, CommonFinder<Release>>();
            services.AddScoped<ICommonFinder<Playlist>, CommonFinder<Playlist>>();
            services.AddScoped<ICommonFinder<Favorite>, CommonFinder<Favorite>>();
            services.AddScoped<ICommonFinder<AudioSource>, CommonFinder<AudioSource>>();
            services.AddScoped<ICommonFinder<VideoClip>, CommonFinder<VideoClip>>();
            services.AddScoped<ICommonFinder<Comment>, CommonFinder<Comment>>();


            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Artist>, Repository<Artist>>();
            services.AddScoped<IRepository<Genre>, Repository<Genre>>();
            services.AddScoped<IRepository<Song>, Repository<Song>>();
            services.AddScoped<IRepository<Release>, Repository<Release>>();
            services.AddScoped<IRepository<Playlist>, Repository<Playlist>>();
            services.AddScoped<IRepository<Favorite>, Repository<Favorite>>();
            services.AddScoped<IRepository<AudioSource>, Repository<AudioSource>>();
            services.AddScoped<IRepository<VideoClip>, Repository<VideoClip>>();
            services.AddScoped<IRepository<Comment>, Repository<Comment>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IService<User>, Service<User>>();
            services.AddScoped<IService<Artist>, Service<Artist>>();
            services.AddScoped<IService<Genre>, Service<Genre>>();
            services.AddScoped<IService<Song>, Service<Song>>();
            services.AddScoped<IService<Release>, Service<Release>>();
            services.AddScoped<IService<Playlist>, Service<Playlist>>();
            services.AddScoped<IService<Favorite>, Service<Favorite>>();
            services.AddScoped<IService<AudioSource>, Service<AudioSource>>();
            services.AddScoped<IService<VideoClip>, Service<VideoClip>>();
            services.AddScoped<IService<Comment>, Service<Comment>>();

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
