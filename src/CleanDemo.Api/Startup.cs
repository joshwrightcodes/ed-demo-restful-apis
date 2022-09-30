// --------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Josh Wright">
// Copyright 2021 Josh Wright.
// Use of this source code is governed by an MIT-style, license that can be found
// in the LICENSE file or at https://opensource.org/licenses/MIT.
// </copyright>
// --------------------------------------------------------------------------------

using System.Reflection;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WrightCodes.CleanDemo.Api.Filters;

namespace WrightCodes.CleanDemo.Api;

public class Startup
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Startup" /> class.
    /// </summary>
    /// <param name="configuration">The configuration provider for the application.</param>
    public Startup(IConfiguration configuration) => Configuration = configuration;

    /// <summary>
    /// Gets the application Configuration provider.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Configure Services for Dependency Injection.
    /// </summary>
    /// <param name="services">Services Collection to append services to.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        // Health Checks
        services.AddHealthChecks();

        // Register Controllers
        services
            .AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
            .AddFluentValidation();

        // Register Options.
        services
            .Configure<ForwardedHeadersOptions>(Configuration.GetSection(nameof(ForwardedHeadersOptions)))
            .Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        services.AddHttpContextAccessor();

        // Register RazorPages
        services.AddRazorPages();

        // CORS
        services.AddCors(options =>
        {
            var policy = new CorsPolicy();
            Configuration.Bind(nameof(CorsPolicy), policy);
            options.AddPolicy(nameof(CorsPolicy), policy);
        });

        // Add Api Versioning
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new MediaTypeApiVersionReader(), // Preferred Versioning
                    new QueryStringApiVersionReader());
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            })
            .AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

        // OpenApi Config
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean Demo", Version = "v1" });

            // Set the comments path for the Swagger JSON and UI.
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            // https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters
            // options.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id
            // options.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]

            options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            options.OperationFilter<SecurityRequirementsOperationFilter>();
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
            });
        });

        services.AddFluentValidationRulesToSwagger();

        // Routing
        services.AddRouting(options => options.LowercaseUrls = true);
    }

    /// <summary>
    /// Configures Application and Http Pipeline.
    /// </summary>
    /// <param name="app">Application Builder.</param>
    /// <param name="env">Web hosting Environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseForwardedHeaders();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors(nameof(CorsPolicy));
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller}/{action=Index}/{id?}");

            endpoints.MapRazorPages();
        });
    }
}