using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using XPTO.API.ViewModels;
using XPTO.API.Entities;
using XPTO.API.Infrastructure.Interfaces;
using XPTO.API.Infrastructure.Repositories;
using XPTO.API.Infrastructure.Context;
using XPTO.API.Services.Dtos;
using XPTO.API.Services.Interfaces;
using XPTO.API.Services.Services;

namespace XPTO.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Environment = env;
      Configuration = configuration;
    }

    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();

      #region AutoMapper

      var autoMapperConfig = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<OrdemDeServico, OrdemDeServicoDto>().ReverseMap();
        cfg.CreateMap<OrdemDeServicoViewModel, OrdemDeServicoDto>().ReverseMap();
      });

      services.AddSingleton(autoMapperConfig.CreateMapper());

      #endregion

      services.AddSingleton(d => Configuration);
      services.AddScoped(typeof(IOrdemDeServicoService), typeof(OrdemDeServicoService));
      services.AddScoped(typeof(IOrdemDeServicoRepository), typeof(OrdemDeServicoRepository));

      services.AddDbContext<OrdemDeServicoContext>(options =>
      {
        var connectionString = Configuration.GetConnectionString("OrdemDeServicoContext");

        options.UseSqlServer(connectionString);
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=OrdemDeServico}/{action=Index}/{id?}");
      });
    }
  }
}