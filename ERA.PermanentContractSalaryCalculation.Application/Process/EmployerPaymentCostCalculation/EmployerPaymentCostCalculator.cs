using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation.Calculations;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation
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
