using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Services.VehicleServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarRentalAPI
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
      services.AddControllers();

      //services.AddDbContext<CarRentalDBContext>(options =>
      //  options.UseSqlServer(Configuration.GetConnectionString("CarRentalDBContext")));

      services.AddDbContext<CarRental.Data.Entities.CarRentalDBContext>(
           e =>
           {
             e.EnableSensitiveDataLogging();
             e.UseSqlServer(Configuration.GetConnectionString("CarRentalDBContext"));
           });
      services.AddMvc();

      //var builder = new WebHostBuilder()
      //.UseStartup<Startup>()
      //.UseSetting("ConnectionStrings:DefaultConnection", "data source=DESKTOP-3KTNVKB;initial catalog=CarRentalDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

      // I want to make sure that I bound through DI my VehicleServices class
      services.AddSingleton<IVehicleServices, VehicleServices>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
