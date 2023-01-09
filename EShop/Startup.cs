using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using EShop.Helpers;
using EShop.Repositories.Customers;
using EShop.Repositories.Orders;
using EShop.Repositories.Products;
using EShop.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using EShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;
using ISession = EShop.Helpers.ISession;

namespace EShop
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISession, Session>();
            services.AddScoped<IUserAccess, UserAccess>();
            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext;
                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionDescriptor.Parameters.Count ==
                        actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("ConsumerAPI", new OpenApiInfo()
                {
                    Title = "ConsumerAPI",
                    Version = "1",
                    Description = "Through this API you can access all of our EShop requests",
                    Contact = new OpenApiContact()
                    {
                        Email = "themtsil@gmail.com",
                        Name = "Themis Tsiligkoudis",
                        Url = new Uri("https://github.com/ttsiligkoudis")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Common Development and Distribution License",
                        Url = new Uri("https://opensource.org/licenses/CDDL-1.0")
                    }
                });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromHours(10);//You can set Time   
            });
            services.AddMvc(setupAction =>
            {
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                setupAction.Filters.Add(new ProducesDefaultResponseTypeAttribute());
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.Filters.Add(new ProducesAttribute("application/json", "application/xml"));
                //setupAction.Filters.Add(new ConsumesAttribute("application/json"));
                setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                var jsonOutputFormatter = setupAction.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()
                    .FirstOrDefault();
                if (jsonOutputFormatter != null)
                {
                    if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }
            });

            services.AddHttpClient("myServiceClient")
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https://localhost:44384/api");
                    client.Timeout = TimeSpan.FromSeconds(5);
                })
                .ConfigurePrimaryHttpMessageHandler(
                    () => new HttpClientHandler() { CookieContainer = new CookieContainer() }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("ConsumerAPI/swagger.json", "ConsumerAPI");
                    setupAction.EnableDeepLinking();
                    setupAction.DisplayOperationId();
                });

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
