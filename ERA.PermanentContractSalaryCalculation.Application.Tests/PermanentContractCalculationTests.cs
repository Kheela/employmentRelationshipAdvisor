using ERA.PermanentContractSalaryCalculation.Application.Process;
using ERA.PermanentContractSalaryCalculation.Application.Process.Calculations;
using FluentAssertions;
using NUnit.Framework;

namespace ERA.PermanentContractSalaryCalculation.Application.Tests
{
    public class PermanentContractCalculationTests
    {
        [TestCase(2000, 274.2)]
        public void PermanentContract__SalaryGross_eq__SocialInsuranceCost_eq(
            decimal salaryGross, 
            decimal expectedValue)
        {
            // arrange
            var setting = EmployeeExampleValues.SocialInsuranceSetting;
            var builder = new EmployeeSalaryCalculationResultBuilder();

            // act
            var result = builder
                .SetSalaryGross(salaryGross)
                .CreateResult()
                .CalculateSocialInsurance(setting)
                .Result
                .TotalSocialInsurance;

            // assert
            result.Should().Be(expectedValue);
        }

        [TestCase(2000, 0, 1615)]
        public void PermanentContract__SalaryGross_eq_and_CopyrightLawsPercent_eq_and__TaxBase_eq(
            decimal salaryGross,
            float copyrightLawsPercent,
            decimal expectedValue)
        {
            // arrange
            var setting = EmployeeExampleValues.SocialInsuranceSetting;
            var employmentRelationshipTaxDeductibles = EmployeeExampleValues.EmploymentRelationshipTaxSetting.DeductiblesAmount;
            var builder = new EmployeeSalaryCalculationResultBuilder();

            // act
            var result = builder
                .SetSalaryGross(salaryGross)
                .CreateResult()
                .CalculateSocialInsurance(setting)
                .CalculateTaxBase(copyrightLawsPercent, builder.Result.TotalSocialInsurance, employmentRelationshipTaxDeductibles)
                .Result
                .TaxBase;

            // assert
            result.Should().Be(expectedValue);
        }

        [TestCase(2000, 155.322, 134)]
        public void PermanentContract__SalaryGross_eq__HealthInsurance_eq(
            decimal salaryGross,
            decimal expectedHealthInsurance,
            decimal expectedHealthInsuranceDeductibles)
        {
            // arrange
            var socialSetting = EmployeeExampleValues.SocialInsuranceSetting;
            var healthSetting = EmployeeExampleValues.HealthInsuranceSetting;
            var builder = new EmployeeSalaryCalculationResultBuilder();

            // act
            var result = builder
                .SetSalaryGross(salaryGross)
                .CreateResult()
                .CalculateSocialInsurance(socialSetting)
                .CalculateHealthInsurance(builder.Result.TotalSocialInsurance, healthSetting)
                .Result;

            // assert
            result.HealthInsurance.Should().Be(expectedHealthInsurance);
            result.HealthInsuranceDeductibles.Should().Be(expectedHealthInsuranceDeductibles);
        }

        [TestCase(2000, 0, 110)]
        public void PermanentContract__SalaryGross_eq_and_CopyrightLawsPercent_eq__Tax_eq(
            decimal salaryGross,
            float copyrightLawsPercent,
            decimal expectedValue)
        {
            // arrange
            var calculator = new EmployeeEmployeeSalaryCalculator();

            var context = new EmployeeSalaryCalculationContext();
            context.Parameters.SocialInsuranceSetting = EmployeeExampleValues.SocialInsuranceSetting;
            context.Parameters.HealthInsuranceSetting = EmployeeExampleValues.HealthInsuranceSetting;
            context.Parameters.EmploymentRelationshipTaxSetting = EmployeeExampleValues.EmploymentRelationshipTaxSetting;

            // act
            var calculationResult = calculator.Calculate(salaryGross, copyrightLawsPercent, context);

            // assert
            calculationResult.Tax.Should().Be(expectedValue);
        }

        [TestCase(2000, 0, 1460)]
        public void PermanentContract__SalaryGross_eq_and_CopyrightLawsPercent_eq__SalaryNett_eq(
            decimal salaryGross,
            float copyrightLawsPercent,
            decimal expectedValue)
        {
            // arrange
            var calculator = new EmployeeEmployeeSalaryCalculator();

            var context = new EmployeeSalaryCalculationContext();
            context.Parameters.SocialInsuranceSetting = EmployeeExampleValues.SocialInsuranceSetting;
            context.Parameters.HealthInsuranceSetting = EmployeeExampleValues.HealthInsuranceSetting;
            context.Parameters.EmploymentRelationshipTaxSetting = EmployeeExampleValues.EmploymentRelationshipTaxSetting;

            // act
            var calculationResult = calculator.Calculate(salaryGross, copyrightLawsPercent, context);

            // assert
            calculationResult.SalaryNett.Should().Be(expectedValue);
        }
    }
}
