using ApiProjeto.Application.Interfaces;
using ApiProjeto.Application.Models;
using ApiProjeto.Application.Service;
using ApiProjeto.Domain.Entities;
using ApiProjeto.Domain.Interfaces;
using ApiProjeto.Infra.Data.Context;
using ApiProjeto.Infra.Data.Repository;
using ApiProjeto.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ApiProjeto.Application
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

            services.AddDbContext<ApiProjetoContext>(options =>
            {
                var server = Configuration["ApiProjetoContext"];

                options.UseSqlServer(server, opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IPessoaApplicationService, PessoaApplicationService>();
            services.AddScoped<IPessoaRepository, PessoaRepository<Pessoa>>();
            services.AddScoped<IPessoaService, PessoaService>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreatePessoaModel, Pessoa>();
                config.CreateMap<UpdatePessoaModel, Pessoa>();
                config.CreateMap<Pessoa, PessoaModel>();
            }).CreateMapper());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiProjeto", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProjeto V1");
                opt.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
