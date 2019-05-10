using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;

namespace ERA.Shared.DI
{
    public static class AutofacExtensions
    {
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAllAssemblyTypes(
            this ContainerBuilder containerBuilder,
            Assembly assembly)
        {
            return containerBuilder
                .RegisterAssemblyTypes(assembly)
                .PublicOnly()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
