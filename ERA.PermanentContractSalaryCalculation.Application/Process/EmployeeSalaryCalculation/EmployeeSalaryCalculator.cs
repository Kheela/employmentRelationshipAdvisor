using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation.Calculations;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation
{
    public interface IEmployeeSalaryCalculator
    {
        EmployeeSalaryCalculationResult Calculate(
            decimal salaryGross,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            EmployeeSalaryCalculationContext context);
    }

    public class EmployeeSalaryCalculator : IEmployeeSalaryCalculator
    {
        private IEmployeeSalaryCalculationResultBuilder _builder;

        public EmployeeSalaryCalculator(
            IEmployeeSalaryCalculationResultBuilder builder)
        {
            _builder = builder;
        }

        public EmployeeSalaryCalculationResult Calculate(
            decimal salaryGross, 
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            EmployeeSalaryCalculationContext context)
        {
            var result = _builder
                .SetSalaryGross(salaryGross)
                .CreateResult()
                .CalculateSocialInsurance(context.Parameters.SocialInsuranceSetting)
                .CalculateTaxBase(copyrightLawsPercent, _builder.Result.TotalSocialInsurance, context.Parameters.EmploymentRelationshipTaxSetting.DeductiblesAmount)
                .CalculateHealthInsurance(_builder.Result.TotalSocialInsurance, context.Parameters.HealthInsuranceSetting)
                .CalculateTaxMonthlyExemption()
                .CalculateTax(_builder.Result.TaxBase, _builder.Result.TaxMonthlyExemption, _builder.Result.HealthInsuranceDeductibles)
                .CalculateSalaryNett(_builder.Result.Tax, _builder.Result.TotalSocialInsurance, _builder.Result.HealthInsurance)
                .Result;

            return result;
        }
    }
}
