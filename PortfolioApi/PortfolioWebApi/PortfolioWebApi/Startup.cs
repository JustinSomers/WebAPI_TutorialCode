using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PortfolioWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioWebApi
{
    public class Startup
    {
        public static string ConnectionSTring { get; private set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // services.Configure<AWSConfig>(Program.Configuration.GetSection("AWS_Strings"));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(Program.Configuration.GetSection("AWS_Strings").Get<AWS_Strings>());
            //services.AddTransient<AWSConnections>();
            services.AddDbContext<ArticleContext>(opt => opt.UseSqlServer(Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection")));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
