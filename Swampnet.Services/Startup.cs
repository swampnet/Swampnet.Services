using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using Serilog.Exceptions;
using Swampnet.Evl;
using Microsoft.Extensions.Hosting;
using Swampnet.Services.HostedBackgroundService;

namespace Swampnet.Services
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddBooksApi();
            services.AddImagesApi();
            services.AddCors();

            // Register Hosted Services
            services.AddSingleton<IHostedService, TestBackgroundService>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Swampnet.Services",
                    Version = "v1",
                    Description = "Backend API for Swampnet.Services"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
                .Enrich.WithExceptionDetails()
				.WriteTo.EvlSink(
					Configuration["evl:api-key"],
					Configuration["evl:endpoint"],
                    typeof(Startup).Assembly.GetName().Name,
                    typeof(Startup).Assembly.GetName().Version.ToString())
				.CreateLogger();

            if (!env.IsDevelopment())
            {
                Log.Logger.WithTag("START").Information("Start");
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swampnet.Services V1");
                });
            }

            app.UseCors(cfg =>
                cfg.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseMvc();
        }
    }
}
