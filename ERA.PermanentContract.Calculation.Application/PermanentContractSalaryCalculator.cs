using System;
using ERA.Shared.Extensions;

namespace ERA.PermanentContract.Calculation.Application
{
    public class PermanentContractSalaryCalculationResult
    {
        public decimal SalaryBrutto { get; set; }

        public decimal SocialInsuranceContribution { get; set; }

        public decimal PensionInsuranceContribution { get; set; }
        public decimal DisabilityPensionInsuranceContribution { get; set; }
        public decimal SicknessInsuranceContribution { get; set; }

        public decimal TaxDeductibleExpenses { get; set; }
        public decimal DriveExpenses { get; set; }

        public decimal CopyrightLawsValue { get; set; }
        public decimal CopyrightLawsCosts { get; set; }

        public decimal TaxBase { get; set; }

        public decimal HealthInsurance { get; set; }
        public decimal HealthInsurancePaidFromTax { get; set; }
        public decimal HealthInsurancePaidFromNetto { get; set; }

        public decimal Tax { get; set; }

        public decimal SalaryNetto { get; set; }
    }

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

            result.PensionInsuranceContribution = socialParameters.PensionInsuranceContributionPercentage.PercentageOf(result.SalaryBrutto);
            result.DisabilityPensionInsuranceContribution = socialParameters.DisabilityPensionInsuranceContributionPercentage.PercentageOf(result.SalaryBrutto);
            result.SicknessInsuranceContribution = socialParameters.SicknessInsuranceContributionPercentage.PercentageOf(result.SalaryBrutto);
            result.SocialInsuranceContribution = socialParameters.TotalPercentage.PercentageOf(result.SalaryBrutto);

            return result;
        }

        private PermanentContractSalaryCalculationResult CalculateDeductibles(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            // koszty uzysku z calej pensji - pomijam na razie
            var deductibleParameters = context.EmployeeContributionParameters.DeductibleParameters;

            result.TaxDeductibleExpenses = deductibleParameters.TaxDeductibleExpensesPercentage.PercentageOf(result.SalaryBrutto);
            result.DriveExpenses = deductibleParameters.DriveExpenses;

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.CopyrightLawsValue = deductibleParameters.CopyrightLawsPercentage.PercentageOf(salaryMinusSocial);
            result.CopyrightLawsCosts = PermanentContractConsts.CopyrightLawsCostsPercentage.PercentageOf(result.CopyrightLawsValue);

            return result;
        }

        private static void CalculateHealthInsuranceContribution(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var healthParameters = context.EmployeeContributionParameters.HealthInsuranceContributionParameters;
            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.HealthInsurance = healthParameters.TotalHealthInsurancePercentage.PercentageOf(salaryMinusSocial);
            result.HealthInsurancePaidFromTax = healthParameters.HealthInsurancePaidFromTaxPercentage.PercentageOf(salaryMinusSocial);
            result.HealthInsurancePaidFromNetto = result.HealthInsurance - result.HealthInsurancePaidFromTax;
        }

        private static void CalculateTax(PermanentContractSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var taxRelief = context.EmployeeContributionParameters.TaxRelief;

            // 3. zaliczka na podatek
            result.Tax = Math.Max(0, PermanentContractConsts.TaxPercentage.PercentageOf(result.TaxBase) - taxRelief - result.HealthInsurancePaidFromTax);
        }

        private static void CalculateNettoSalary(PermanentContractSalaryCalculationResult result)
        {
            result.SalaryNetto = result.SalaryBrutto - result.Tax - result.SocialInsuranceContribution - result.HealthInsurance;
        }
    }
}
