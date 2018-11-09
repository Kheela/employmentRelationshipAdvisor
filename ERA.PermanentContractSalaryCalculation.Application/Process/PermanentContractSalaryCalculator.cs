using System;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Domain.Constants;
using ERA.PermanentContractSalaryCalculation.Domain.Enumerations;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public interface IPermanentContractSalaryCalculator
    {
        PermanentContractSalaryCalculationResult Calculate(
            decimal salaryBrutto,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            PermanentContractSalaryCalculationContext context);
    }

    public class PermanentContractSalaryCalculator : IPermanentContractSalaryCalculator
    {
        public PermanentContractSalaryCalculationResult Calculate(
            decimal salaryBrutto, 
            //todo: decimal driveExpenses,
            float copyrightLawsPercent,
            PermanentContractSalaryCalculationContext context)
        {
            var result = new PermanentContractSalaryCalculationResult
            {
                SalaryBrutto = salaryBrutto
            };

            CalculateTaxBase(copyrightLawsPercent, result, context);
            CalculateHealthInsuranceContribution(result, context);
            CalculateTax(result, context);
            CalculateNettoSalary(result);

            return result;
        }

        public PermanentContractSalaryCalculationResult CalculateTaxBase(
            float copyrightLawsPercent,
            PermanentContractSalaryCalculationResult result, 
            PermanentContractSalaryCalculationContext context)
        {
            CalculateSocialInsuranceContribution(result, context);
            CalculateDeductibles(copyrightLawsPercent, result, context);

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;
            result.TaxBase = salaryMinusSocial - result.CopyrightLawsCosts; // deductibles

            return result;
        }

        private PermanentContractSalaryCalculationResult CalculateSocialInsuranceContribution(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var socialParameters = context.Parameters.SocialInsuranceSetting;

            result.PensionInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.RetirementInsurancePercent);
            result.DisabilityPensionInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.DisabilityPensionInsurancePercent);
            result.SicknessInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.SicknessInsurancePercent);
            result.SocialInsuranceContribution = result.SalaryBrutto.GetPercent(socialParameters.TotalPercent);

            return result;
        }

        private PermanentContractSalaryCalculationResult CalculateDeductibles(
            float copyrightLawsPercent,
            PermanentContractSalaryCalculationResult result, 
            PermanentContractSalaryCalculationContext context)
        {
            // koszty uzysku z calej pensji - pomijam na razie
            var taxDeductibleExpenses = context.Parameters.EmploymentRelationshipTaxDeductibleExpensesSetting;
            result.TaxDeductibleExpenses = taxDeductibleExpenses.Amount;

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.CopyrightLawsValue = salaryMinusSocial.GetPercent(copyrightLawsPercent);
            result.CopyrightLawsCosts = result.CopyrightLawsValue.GetPercent(CopyrightLawsCosts.Percent);

            return result;
        }

        private static void CalculateHealthInsuranceContribution(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var healthParameters = context.Parameters.HealthInsuranceSetting;
            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.HealthInsurance = salaryMinusSocial.GetPercent(healthParameters.HealthInsurancePercent);
            result.DeductibleHealthInsurance = Math.Floor(salaryMinusSocial.GetPercent(healthParameters.DeductibleHealthInsurancePercent));
            result.HealthInsurancePaidFromNetto = result.HealthInsurance - result.DeductibleHealthInsurance;
        }

        private static void CalculateTax(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            result.MonthlyTaxExemption = CalculateMonthlyTaxExemption(result.TaxBase);

            // 3. zaliczka na podatek
            result.Tax = Math.Max(0, result.TaxBase.GetPercent(TaxThreshold._18)) - result.MonthlyTaxExemption - result.DeductibleHealthInsurance;
        }

        private static decimal CalculateMonthlyTaxExemption(decimal taxBase)
        {
            // 1/12 z kwoty wolnej od podatku (bo jest ona roczna)
            // od 2018r wyliczana inaczej w zaleznosci od podstawy opodatkowania
            return 46.33m;
        }

        private static void CalculateNettoSalary(PermanentContractSalaryCalculationResult result)
        {
            result.SalaryNetto = result.SalaryBrutto - result.Tax - result.SocialInsuranceContribution - result.HealthInsurance;
        }
    }
}
