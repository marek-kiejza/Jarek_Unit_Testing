namespace SolidSavings.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using SolidSavings.Web.Controllers;
    using SolidSavings.Web.DataAccess;
    using SolidSavings.Web.Logic;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IBusiness, Business>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            //services.AddSingleton<ISolidDatabase, InMemoryDatabase>();
            services.AddScoped<ISolidDatabase, EFDatabase>();
            services.AddScoped<ISolidExporter, SolidExporter>();
            
            services.AddScoped<ISolidFileExporter, SolidExporterJson>();
            services.AddScoped<ISolidFileExporter, SolidExporterXlsx>();
            services.AddScoped<ISolidFileExporter, SolidExporterXml>();
            services.AddScoped<ISolidFileExporter, SolidExporterText>();

            services.AddDbContext<SqlContext>(
                o => o.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authorization}/{action=Login}");
            });
        }
    }
}
