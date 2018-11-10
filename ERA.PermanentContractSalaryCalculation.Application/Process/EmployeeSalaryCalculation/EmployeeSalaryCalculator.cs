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

    public class EmployeeEmployeeSalaryCalculator : IEmployeeSalaryCalculator
    {
        public EmployeeSalaryCalculationResult Calculate(
            decimal salaryGross, 
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            EmployeeSalaryCalculationContext context)
        {
            var builder = new EmployeeSalaryCalculationResultBuilder();

            var result = builder
                .SetSalaryGross(salaryGross)
                .CreateResult()
                .CalculateSocialInsurance(context.Parameters.SocialInsuranceSetting)
                .CalculateTaxBase(copyrightLawsPercent, builder.Result.TotalSocialInsurance, context.Parameters.EmploymentRelationshipTaxSetting.DeductiblesAmount)
                .CalculateHealthInsurance(builder.Result.TotalSocialInsurance, context.Parameters.HealthInsuranceSetting)
                .CalculateTaxMonthlyExemption()
                .CalculateTax(builder.Result.TaxBase, builder.Result.TaxMonthlyExemption, builder.Result.HealthInsuranceDeductibles)
                .CalculateSalaryNett(builder.Result.Tax, builder.Result.TotalSocialInsurance, builder.Result.HealthInsurance)
                .Result;

            return result;
        }
    }
}
