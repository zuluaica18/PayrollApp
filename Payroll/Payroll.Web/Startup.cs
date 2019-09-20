using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payroll.BusinessLogic.Domain.Actor;
using Payroll.BusinessLogic.Domain.Actor.AccountantAssistant;
using Payroll.Infraestructure;
using Payroll.Infraestructure.Domain.Actor;

namespace Payroll.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<Accountant>();
            services.AddScoped<SecretaryDao>();
            services.AddTransient<AccountantAssistantMapping>();
            services.AddTransient<AccountantAssistantSalaryHourly>();
            services.AddTransient<AccountantAssistantSalaryMonthtly>();
            services.AddTransient<IAccountantAssistantSalary>(serviceProvider => {
                return Accountant.employeTemp.typeContract == 1
                    ? serviceProvider.GetService<AccountantAssistantSalaryHourly>() as IAccountantAssistantSalary
                    : serviceProvider.GetService<AccountantAssistantSalaryMonthtly>() as IAccountantAssistantSalary;
            });
            services.AddDbContext<DbContextSistema>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Conexion")));
            // Erase please
            services.AddCors(options => {
                options.AddPolicy("All",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("All");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
