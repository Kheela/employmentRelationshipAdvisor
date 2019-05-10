using Autofac;
using ERA.Shared.DI;

namespace ERA.PermanentContractSalaryCalculation.Application.DI
{
    public class PermanentContractSalaryCalculationModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterAllAssemblyTypes(ThisAssembly);
        }
    }
}
