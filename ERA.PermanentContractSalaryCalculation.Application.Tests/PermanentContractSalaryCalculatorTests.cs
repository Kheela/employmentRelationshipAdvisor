using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process.Calculators;
using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;

namespace ERA.PermanentContractSalaryCalculation.Application.Tests
{
    public class PermanentContractSalaryCalculatorTests
    {
        [TestCase(2000, 274.2)]
        public void PermanentContract__SalaryBrutto_eq__RetirementInsuranceCost_eq(decimal salaryBrutto, decimal expectedSocialInsuranceCost)
        {
            var result = new PermanentContractSalaryCalculationResult();

            result.CalculateSocialInsurance(salaryBrutto, new SocialInsuranceSetting
            {
                RetirementInsurancePercent = PermanentContractEmployeeExampleValues.SocialInsuranceSetting.RetirementInsurancePercent,
                DisabilityPensionInsurancePercent = PermanentContractEmployeeExampleValues.SocialInsuranceSetting.DisabilityPensionInsurancePercent,
                SicknessInsurancePercent = PermanentContractEmployeeExampleValues.SocialInsuranceSetting.SicknessInsurancePercent
            });

            result.Should().IsSameOrEqualTo(expectedSocialInsuranceCost);
        }
    }
}
