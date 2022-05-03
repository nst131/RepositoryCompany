using DL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DL
{
    public static class ServiceRegistrationDA
    {
        public static void AddRegistrationDA(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDataContext, DataContext>();
        }
    }
}

