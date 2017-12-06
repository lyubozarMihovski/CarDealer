namespace CarDealer.App
{
    using CarDealer.App.Models;
    using CarDealer.Data;
    using CarDealer.Domain;
    using CarDealer.Services;
    using CarDealer.Services.Implementations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

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
            services.AddDbContext<CarDealerDbContext>(options => options.UseSqlServer("Server=.;Database=CarDealerDb;Integrated Security=True;", b => b.MigrationsAssembly("CarDealer.App")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<CarDealerDbContext>()
              .AddDefaultTokenProviders();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISaleService, SaleService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<IEmailSender, EmailSender>();
           

            services.AddMvc(options => 
            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "customers",
                    template: "customers/all/{order}",
                    defaults: new { controller = "Customers", action = "All"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
