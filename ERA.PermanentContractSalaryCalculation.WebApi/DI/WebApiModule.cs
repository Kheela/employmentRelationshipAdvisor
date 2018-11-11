using Autofac;
using Autofac.Integration.WebApi;

namespace ERA.PermanentContractSalaryCalculation.WebApi.DI
{
    public class WebApi : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterApiControllers(ThisAssembly);
        }
    }
}
