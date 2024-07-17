using System.Reflection;

namespace Order.Api.Extensions
{
    public static class ApiRegistration
    {
        public static IServiceCollection AddApiRegestration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;    
        }



    }
}
