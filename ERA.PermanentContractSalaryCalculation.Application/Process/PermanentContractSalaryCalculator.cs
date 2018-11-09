using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process.Calculations;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public interface IPermanentContractSalaryCalculator
    {
        PermanentContractSalaryCalculationResult Calculate(
            decimal salaryGross,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            PermanentContractSalaryCalculationContext context);
    }

    public class PermanentContractSalaryCalculator : IPermanentContractSalaryCalculator
    {
        public PermanentContractSalaryCalculationResult Calculate(
            decimal salaryGross, 
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            PermanentContractSalaryCalculationContext context)
        {
            var builder = new CalculationResultBuilder();

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
