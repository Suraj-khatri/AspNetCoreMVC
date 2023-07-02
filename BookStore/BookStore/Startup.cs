using BookStore.Controllers;
using BookStore.Data;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDbContextPool<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("dbConnection")));
            // adding run time compilation package
            //this slows our performance so we only use in developing mode not production so use if statement
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddTransient<BookRepository, BookRepository>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // this is for running staticfiles. without this our static files will not run or app willnot know about our static files
            app.UseStaticFiles();

            //if you want to make other folder as static like "MyStaticFiles",then we should do this
           /* app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"MyStaticFiles")),
                RequestPath = "/MyStaticFiles"
            });
            */


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
