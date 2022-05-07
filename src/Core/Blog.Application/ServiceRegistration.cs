﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
