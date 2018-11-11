using Autofac;
using System;

namespace ERA.Externals.DI
{
    public class AutofacContainer
    {
        public static IContainer Container => ContainerCreator.Value;

        private static readonly Lazy<IContainer> ContainerCreator = new Lazy<IContainer>(Create);

        private static IContainer Create()
        {
            var builder = new ContainerBuilder();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyModules(assemblies);
            var container = builder.Build();

            return container;
        }
    }
}
