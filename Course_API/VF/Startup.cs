using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Course_API.Models;
using Course_API.Options;
using Course_API.Providers;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Course_API.Repository;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.SignalR.Configuration;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Course_API.CustomAttribute;
using AutoMapper;
using System.Reflection;
using Course_API.Models.BindingModels.Course;
using Course_API.Models.ReturnModels.Webs;
using Course_API.Models.DatabaseModels.RelianceModels;
using Course_API.Models.BindingModels.Institute;
using Course_API.Models.ReturnModels.CourseReturnModels;
using Course_API.Models.ReturnModels;
using Course_API.Models.DatabaseModels.CourseModels;
using Course_API.Models.TrainerModels;
using Course_API.Models.ReturnModels.TrainerReturnModels;
using Course_API.Models.DatabaseModels.RelModels;
using Course_API.Models.BindingModels.Trainer;

namespace Course_API
{
    public class Startup
    {
        private readonly SecurityKey securityKey;
        private readonly IConfigurationSection jwtAppSettingOptions;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("SecurityKey").Value));
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }, ArrayPool<char>.Shared));
            });


            //For Localization

            //services.AddLocalization(options => options.ResourcesPath = "Resources");
            //services.AddMvc()
            //    .AddViewLocalization()
            //    .AddDataAnnotationsLocalization();

            //services.AddScoped<LanguageActionFilter>();

            //services.Configure<RequestLocalizationOptions>( options =>
            //{
            //    var supportedCultures = new List<CultureInfo>
            //        {
            //            new CultureInfo("en-US"),
            //            new CultureInfo("vi"),
            //        };

            //    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
            //    options.SupportedCultures = supportedCultures;
            //    options.SupportedUICultures = supportedCultures;
            //});


            services.AddCors();

            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
            });

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<VfDbContext, int>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IFacebookProvider, FacebookProvider>();
            services.AddSingleton<IGooglePlusProvider, GooglePlusProvider>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v2",
                    Title = "NOWN",
                    Description = "CODUX",
                    Contact = new Contact()
                    { Name = "Duc Nguyen", Email = "nvduc2910@gmail.com", }
                });
               
                //c.IncludeXmlComments(GetXmlCommentsPath(PlatformServices.Default.Application));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = string.Empty;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<VfDbContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            });

            services.Configure<FacebookOptions>(options =>
            {
                options.AppId = Configuration.GetSection("FacebookConfigOptions:AppId").Value;
                options.AppSecret = Configuration.GetSection("FacebookConfigOptions:AppSecret").Value;
                options.Fields.Add("picture");
                options.SendAppSecretProof = false;
            });
            
            services.Configure<GoogleOptions>(options =>
            {
                options.ClientId = Configuration.GetSection("GoogleConfigOptions:AppId").Value;
                options.ClientSecret = Configuration.GetSection("GoogleConfigOptions:AppSecret").Value;
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<int, CourTra>()
               .ForMember(dest => dest.TrainerId, opts => opts.MapFrom(src => src));


                cfg.CreateMap<int, CourRel>()
                .ForMember(dest => dest.RelianceId, opts => opts.MapFrom(src => src));


                cfg.CreateMap<CourseDTO, Course>()
                .ForMember(dest => dest.CourseScope, opts => opts.Ignore())
                .ForMember(dest => dest.Institude, opts => opts.Ignore())
                .ForMember(dest => dest.CourseStatus, opts => opts.Ignore())
                .ForMember(dest => dest.CourseType, opts => opts.Ignore())
                .ForMember(dest => dest.CourseLevel, opts => opts.Ignore())
                .ForMember(dest => dest.CourseCategory, opts => opts.Ignore())
                .ForMember(dest => dest.CourseLanguage, opts => opts.Ignore())
                .ForMember(dest => dest.Currency, opts => opts.Ignore())
                .ForMember(dest => dest.CourseCancelReason, opts => opts.Ignore())

                .ForMember(dest => dest.Organizer, opts => opts.Ignore())
                .ForMember(dest => dest.CourTra, opts => opts.MapFrom(src => src.Trainers))
                .ForMember(dest => dest.CourRel, opts => opts.MapFrom(src => src.Reliances))
                .ForMember(dest => dest.CourseDayType, opts => opts.Ignore())
                .ForMember(dest => dest.CourseFavorite, opts => opts.Ignore());


                cfg.CreateMap<InstituteDTO, Institute>()
                .ForMember(dest => dest.Country, opts => opts.Ignore())
                .ForMember(dest => dest.City, opts => opts.Ignore())
                .ForMember(dest => dest.InstituteType, opts => opts.Ignore())
                .ForMember(dest => dest.InstitudeFlag, opts => opts.Ignore())
                .ForMember(dest => dest.Course, opts => opts.Ignore())
                .ForMember(dest => dest.Reliance, opts => opts.Ignore())
                .ForMember(dest => dest.User, opts => opts.Ignore());



                cfg.CreateMap<Country,CountryReturnModel>();
                cfg.CreateMap<City, CityReturnModel>();
                cfg.CreateMap<Reliance, RelianceReturnModel>();

                cfg.CreateMap<Institute, InstituteProfileReturnModel>()
                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                .ForMember(dest => dest.InstituteType, opts => opts.MapFrom(src => src.InstituteType))
                .ForMember(dest => dest.Reliance, opts => opts.MapFrom(src => src.Reliance));


                cfg.CreateMap<Course, CourseBriefReturnModel>()
                .ForMember(dest => dest.InstitudeName, opts => opts.MapFrom(src => src.Institude.Name));


                //course details return model

                cfg.CreateMap<CourseScope, CourseScopeReturnModel>();
                cfg.CreateMap<CourseStatus, CourseStatusReturnModel>();
                cfg.CreateMap<CourseType, CourseTypeReturnModel>();
                cfg.CreateMap<Institute, CourseInstituteReturnModel>();
                cfg.CreateMap<CourseLevel, CourseLevel>();
                cfg.CreateMap<CourseCategory, CourseCategoryReturnModel>();
                cfg.CreateMap<CourseLevel, CourseLevel>();
                cfg.CreateMap<CourseCategory, CourseCategoryReturnModel>();
                cfg.CreateMap<CourseLanguage, CourseLanguageReturnModel>();
                cfg.CreateMap<Currency, CurrencyReturnModel>();
                cfg.CreateMap<CourseCancelReason, CourseCancelReasonReturnModel>();
                cfg.CreateMap<CourTra, TrainerBirefReturnModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.Major, opts => opts.MapFrom(src => src.Trainer.Major))
                .ForMember(dest => dest.Avatar, opts => opts.MapFrom(src => src.Trainer.Logo))
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Trainer.Id));


                cfg.CreateMap<CourRel, RelianceReturnModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Reliance.Id))
                .ForMember(dest => dest.Logo, opts => opts.MapFrom(src => src.Reliance.Logo))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Reliance.Name));

                cfg.CreateMap<Course, CourseDetailsReturnModel>()
                .ForMember(dest => dest.CourseScope, opts => opts.MapFrom(src => src.CourseScope))
                .ForMember(dest => dest.CourseStatus, opts => opts.MapFrom(src => src.CourseStatus))
                .ForMember(dest => dest.CourseType, opts => opts.MapFrom(src => src.CourseType))
                .ForMember(dest => dest.CourseInstitute, opts => opts.MapFrom(src => src.Institude))
                .ForMember(dest => dest.CourseLevel, opts => opts.MapFrom(src => src.CourseLevel))
                .ForMember(dest => dest.CourseCategory, opts => opts.MapFrom(src => src.CourseCategory))
                .ForMember(dest => dest.CourseLanguage, opts => opts.MapFrom(src => src.CourseLanguage))
                .ForMember(dest => dest.Currency, opts => opts.MapFrom(src => src.Currency))
                .ForMember(dest => dest.CourseCancelReason, opts => opts.MapFrom(src => src.CourseCancelReason))
                .ForMember(dest => dest.CourseFlag, opts => opts.MapFrom(src => src.CourseFlag))
                .ForMember(dest => dest.Trainer, opts => opts.MapFrom(src => src.CourTra))
                .ForMember(dest => dest.Reliance, opts => opts.MapFrom(src => src.CourRel));


                cfg.CreateMap<TrainerDTO, Trainer>()
                .ForMember(dest => dest.CourTra, opts => opts.Ignore())
                .ForMember(dest => dest.City, opts => opts.Ignore())
                .ForMember(dest => dest.Country, opts => opts.Ignore())
                .ForMember(dest => dest.TrainerTitle, opts => opts.Ignore())
                .ForMember(dest => dest.TrainerNationality, opts => opts.Ignore())
                .ForMember(dest => dest.TrainerStatus, opts => opts.Ignore())
                .ForMember(dest => dest.TrainerFlag, opts => opts.Ignore())
                .ForMember(dest => dest.Institute, opts => opts.Ignore());

      

            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }
        private string GetXmlCommentsPath(ApplicationEnvironment appEnvironment)
        {
            return Path.Combine(appEnvironment.ApplicationBasePath, "BeautyAdvisor.xml");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseCors(
               builder => builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials())
               .UseStaticFiles();
            app.UseWebSockets();

            app.UseSignalR();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseStaticFiles();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VF_v1");
                c.InjectOnCompleteJavaScript("/auth.js");
            });

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = SetTokenValidationParameters()
            });

            app.UseMvc();
        }

        private TokenValidationParameters SetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    }

    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "access token",
                    Required = true,
                    Type = "string"
                });
            }
        }
    }
}
