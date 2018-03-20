using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.Framework.Bus;
using CarDealership.Domain.Framework.CommandHandlers;
using CarDealership.Domain.Framework.Commands;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.Framework.QueryHandlers;
using CarDealership.Domain.Framework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace CarDealership.Web
{
    public class Startup
    {
        private readonly Container _container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            _container.Verify(VerificationOption.VerifyOnly);

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            RegisterDatabaseHandlers(app);

            _container.RegisterSingleton<ServiceBus>();
            _container.RegisterSingleton<ICommandSender, ServiceBus>();
            _container.RegisterSingleton<IQueryProcessor, ServiceBus>();

            RegisterHandlers();
        }

        private void RegisterDatabaseHandlers(IApplicationBuilder app)
        {
            _container.Register(() =>
            {
                var builder = new DbContextOptionsBuilder<CarDealershipContext>();
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                return new CarDealershipContext(builder.Options);
            }, Lifestyle.Transient);

            var repositoryAssembly = typeof(IRepository).Assembly;

            var repositories =
                from type in repositoryAssembly.DefinedTypes
                where type.IsClass && type.GetInterfaces().Any()
                where type.GetInterfaces().First() != typeof(IDisposable)
                where type.GetInterfaces().Contains(typeof(IRepository))
                select new {Service = type.GetInterfaces().First(), Implementation = type};

            foreach (var repository in repositories)
            {
                _container.Register(repository.Service, repository.Implementation, Lifestyle.Transient);
            }
        }

        private void RegisterHandlers()
        {
            var handlerAssembly = typeof(ICommandHandler).Assembly;

            _container.RegisterCollection<ICommandHandler>(new List<Assembly> {handlerAssembly});
            _container.RegisterCollection<IQueryHandler>(new List<Assembly> {handlerAssembly});

            var handlerRegistry = _container.GetInstance<ServiceBus>();

            foreach (var commandHandler in _container.GetServices<ICommandHandler>())
            {
                handlerRegistry.AddCommandHandler(commandHandler);
            }

            foreach (var queryHandler in _container.GetServices(typeof(IQueryHandler)))
            {
                handlerRegistry.AddQueryProcessor((IQueryHandler) queryHandler);
            }
        }
    }
}
