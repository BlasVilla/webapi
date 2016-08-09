using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademySample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AcademySample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];

            // Add framework services.
            services.AddMvc();

            services.AddSwaggerGen();

            services.AddDbContext<ComputerDbContext>(options => options.UseSqlite(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            DbContextOptions<ComputerDbContext> options)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            
            app.UseSwagger();

            app.UseSwaggerUi();
            
            InitializeDatabase(options);
        }
        
        protected void InitializeDatabase(DbContextOptions<ComputerDbContext> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            using (var db = new ComputerDbContext(options))
            {
                db.Database.Migrate();
            }
        }
    }
}
