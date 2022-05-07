using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var executedAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(executedAssembly);
            services.AddMediatR(executedAssembly);
        }
    }
}
