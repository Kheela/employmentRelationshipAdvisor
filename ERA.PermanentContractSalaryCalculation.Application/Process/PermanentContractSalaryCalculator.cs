using System;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Domain.Constants;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public interface IPermanentContractSalaryCalculator
    {
        PermanentContractSalaryCalculationResult Calculate(decimal salaryBrutto, PermanentContractSalaryCalculationContext context);
    }

    public class PermanentContractSalaryCalculator : IPermanentContractSalaryCalculator
    {
        public PermanentContractSalaryCalculationResult Calculate(decimal salaryBrutto, PermanentContractSalaryCalculationContext context)
        {
            var result = new PermanentContractSalaryCalculationResult
            {
                SalaryBrutto = salaryBrutto
            };

            CalculateTaxBase(result, context);
            CalculateHealthInsuranceContribution(result, context);
            CalculateTax(result, context);
            CalculateNettoSalary(result);

            return result;
        }

        public PermanentContractSalaryCalculationResult CalculateTaxBase(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            CalculateSocialInsuranceContribution(result, context);
            CalculateDeductibles(result, context);

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;
            result.TaxBase = salaryMinusSocial - result.CopyrightLawsCosts;

            return result;
        }

        private PermanentContractSalaryCalculationResult CalculateSocialInsuranceContribution(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var socialParameters = context.EmployeeContributionParameters.SocialInsuranceContributionParameters;

            result.PensionInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.RetirementInsurancePercent);
            result.DisabilityPensionInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.DisabilityPensionInsurancePercent);
            result.SicknessInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.SicknessInsurancePercent);
            result.SocialInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.TotalPercent);

            return result;
        }

        private PermanentContractSalaryCalculationResult CalculateDeductibles(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            // koszty uzysku z calej pensji - pomijam na razie
            var deductibleParameters = context.EmployeeContributionParameters.DeductibleParameters;

            result.TaxDeductibleExpenses = result.SalaryBrutto.GetPercent(deductibleParameters.TaxDeductibleExpensesPercent);
            result.DriveExpenses = deductibleParameters.DriveExpenses;

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.CopyrightLawsValue = salaryMinusSocial.GetPercent(deductibleParameters.CopyrightLawsPercent);
            result.CopyrightLawsCosts = result.CopyrightLawsValue.GetPercent(PermanentContractConsts.CopyrightLawsCostsPercentage);

            return result;
        }

        private static void CalculateHealthInsuranceContribution(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var healthParameters = context.EmployeeContributionParameters.HealthInsuranceContributionParameters;
            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.HealthInsurance = salaryMinusSocial.GetPercent(healthParameters.TotalHealthInsurancePercent);
            result.HealthInsurancePaidFromTax = salaryMinusSocial.GetPercent(healthParameters.HealthInsurancePaidFromTaxPercent);
            result.HealthInsurancePaidFromNetto = result.HealthInsurance - result.HealthInsurancePaidFromTax;
        }

        private static void CalculateTax(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var taxRelief = context.EmployeeContributionParameters.TaxRelief;

            // 3. zaliczka na podatek
            result.Tax = Math.Max(0, result.TaxBase.GetPercent(PermanentContractConsts.TaxPercentage)) - taxRelief - result.HealthInsurancePaidFromTax;
        }

        private static void CalculateNettoSalary(PermanentContractSalaryCalculationResult result)
        {
            result.SalaryNetto = result.SalaryBrutto - result.Tax - result.SocialInsuranceContribution - result.HealthInsurance;
        }
    }
}
