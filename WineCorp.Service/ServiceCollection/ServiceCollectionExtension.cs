using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WineCorp.Infrastructure.Context;

namespace WineCorp.Service.ServiceCollection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRegisterTypes(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            RegisterDependencies(services);
            RegisterAutomapper(services);
            RegisterEntityFramework(services,configuration);

            return services;
        }

        private static void RegisterEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            string connString = configuration.GetValue<string>("Connections:WineCorp");
            services.AddDbContext<WineCorpDbContext>(options =>
            options.UseSqlServer(connString,
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure()
                    .CommandTimeout(30);
            }));


        }
        public static void RegisterDependencies(this IServiceCollection services)
        {

            var domainAssembly = Assembly.Load(new AssemblyName("WineCorp.Dom"));
            var dataAssembly = Assembly.Load(new AssemblyName("WineCorp.Infrastructure"));
            var appAssembly = Assembly.Load(new AssemblyName("WineCorp.App"));


            services
                  .Scan(typeSourceSelector => typeSourceSelector
                    .FromAssemblies(domainAssembly, dataAssembly, appAssembly)
                        .AddClasses()
                            .AsMatchingInterface()
                            .WithScopedLifetime()
                            );

        }
        private static void RegisterAutomapper(IServiceCollection services)
        {
          //  services.AddAutoMapper(typeof());
            
        }
    }
}
