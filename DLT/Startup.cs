using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPOI.SS.UserModel;
using System.IO;
using DLT.Models;
using Newtonsoft.Json;
using DLT.Services;
using System.Runtime.Caching;

namespace DLT
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var path = Directory.GetCurrentDirectory() + "/App_Data/";

            ObjectCache cache = MemoryCache.Default;//声明缓存类

            List<DLTModel> modelList = null;

            IFileService<DLTModel> jsonService = new JsonService(path);
            IFileService<DLTModel> xmlService = new XmlService(path);

            modelList = jsonService.GetList();

            if (modelList.Count > 0)
            {
            }
            else
            {
                modelList = xmlService.GetList();

                jsonService.Save(modelList);
            }

            CacheItemPolicy policy = new CacheItemPolicy();//这个对象可以设置这个缓存的过期时间，和关联对象等等等。

            policy.AbsoluteExpiration = DateTime.Now.AddDays(10);//设置过期时间是当前时间+10秒，那么10秒后，这个缓存的项就会被移除

            cache.Set("DLT", modelList, policy);//插入缓存
        }
    }
}
