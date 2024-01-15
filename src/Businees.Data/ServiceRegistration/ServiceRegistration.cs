using Businees.Data.Repositories;
using Business.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Data.ServiceRegistration
{
    public static class ServiceRegistration
    {
       public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }
}
