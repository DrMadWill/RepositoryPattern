using Student.Business.Abstract;
using Student.Business.Concrete;
using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete;
using Student.DataAccess.Concrete.MsSql;

namespace Student.Api.Extensions
{
    /// <summary>
    /// Extension method that registers all application services
    /// Add new Service,UntiOfWork,Repository and implementations here.
    /// </summary>

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped(typeof(IBaseRepostitory<,>), typeof(EfGenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAddressesService, AddressesService>();
            services.AddScoped<IGuardianService, GuardianService>();
            services.AddScoped<IGuradianTypeService, GuradianTypeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IFamiliesService, FamilyService>();
            return services;
        }
    }
}