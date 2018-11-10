using ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation.Models;
using ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation.Process.Calculations;

namespace ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation.Process
{
    public interface IEmployerPaymentCostCalculator
    {
        EmployerPaymentCostCalculationResult Calculate(
            decimal salaryGross,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent, //todo: czy to jest do czegos potrzebne?
            EmployerPaymentCostCalculationContext context);
    }

    public class EmployerPaymentCostCalculator : IEmployerPaymentCostCalculator
    {
        public EmployerPaymentCostCalculationResult Calculate(
            decimal salaryGross, 
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            EmployerPaymentCostCalculationContext context)
        {
            var builder = new EmployerPaymentCostCalculationResultBuilder();

            var result = builder
                .SetSalaryGross(salaryGross)
                .CreateResult()
                .Calculate(context.Parameters.EmployerPaymentCostSetting)
                .Result;

            return result;
        }
    }
}
