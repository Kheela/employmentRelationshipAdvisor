using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation
{
    public class EmployerPaymentCostCalculationContext
    {
        public EmployerPaymentCostParameters Parameters { get; set; } = new EmployerPaymentCostParameters();
    }

    // todo: get from net
    public class EmployerPaymentCostParameters
    {
        public EmployerPaymentCostSetting EmployerPaymentCostSetting { get; set; }
    }
}
