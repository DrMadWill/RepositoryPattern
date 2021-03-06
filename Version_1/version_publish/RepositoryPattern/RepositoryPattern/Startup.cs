using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student.DataAccess.Concrete.MsSQL;
using Student.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Entity.Student;
using Student.Business.Abstract;
using Student.Business.Concrete;
using Microsoft.OpenApi.Models;

namespace RepositoryPattern
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

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            
            services.AddScoped<StudentDbContext>(option => new StudentDbContext(Configuration.GetConnectionString("LocalAppDb")));
            // Add Database
            //services.AddDbContext<StudentDbContext>(options =>
            //{
            //    options.UseSqlite(Configuration.GetConnectionString("LocalDb"));
            //});
            // ================== Repository ==============================
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IGuardianTypeRepository, GuardianTypeRepository>();

            // ==================== Service ============================
            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IGuardianTypeService, GuardianTypeService>();

            services.AddSwaggerGen(c=> new OpenApiInfo
            {
                Version = "v1",
                Title = "Students Course Api",
                Description = "Students Detail Data",
                TermsOfService = new Uri("https://github.com/DrMadWill/RepositoryPattern"),
                Contact = new OpenApiContact
                {
                    Name = "Nofel Salahov (DR Mad Will)",
                    Email = "nofelsalahov9@gmail.com",
                    Url  = new Uri("https://www.linkedin.com/in/drmadwill/")
                }
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Repository Pattern API V1");
                c.RoutePrefix = String.Empty;
            });

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
