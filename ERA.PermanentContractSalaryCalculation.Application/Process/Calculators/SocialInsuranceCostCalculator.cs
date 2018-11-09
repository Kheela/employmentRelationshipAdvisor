using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculators
{
    public static class SocialInsuranceCostCalculator
    {
        public static PermanentContractSalaryCalculationResult CalculateSocialInsurance(
            this PermanentContractSalaryCalculationResult result, 
            decimal salaryBrutto, 
            SocialInsuranceSetting setting)
        {
            result.RetirementInsurance = salaryBrutto.GetPercent(setting.RetirementInsurancePercent);
            result.DisabilityPensionInsurance = salaryBrutto.GetPercent(setting.DisabilityPensionInsurancePercent);
            result.SicknessInsurance = salaryBrutto.GetPercent(setting.SicknessInsurancePercent);
            result.TotalSocialInsurance = salaryBrutto.GetPercent(setting.TotalPercent);

            return result;
        }
    }
}
