using ERA.Shared.Extensions;
using System;

namespace ERA.Calculation.EmploymentContract
{
    public class EmploymentContractCalculationResult
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

    public interface IEmploymentContractCalculator
    {
        EmploymentContractCalculationResult Calculate(decimal salaryBrutto, EmploymentContractCalculationContext context);
    }

    public class EmploymentContractCalculator : IEmploymentContractCalculator
    {
        public EmploymentContractCalculationResult Calculate(decimal salaryBrutto, EmploymentContractCalculationContext context)
        {
            var result = new EmploymentContractCalculationResult
            {
                SalaryBrutto = salaryBrutto
            };

            CalculateTaxBase(result, context);
            CalculateHealthInsuranceContribution(result, context);
            CalculateTax(result, context);
            CalculateNettoSalary(result);

            return result;
        }

        public EmploymentContractCalculationResult CalculateTaxBase(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            CalculateSocialInsuranceContribution(result, context);
            CalculateDeductibles(result, context);

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;
            result.TaxBase = salaryMinusSocial - result.CopyrightLawsCosts;

            return result;
        }

        private EmploymentContractCalculationResult CalculateSocialInsuranceContribution(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            var socialParameters = context.EmployeeContributionParameters.SocialInsuranceContributionParameters;

            result.PensionInsuranceContribution = socialParameters.PensionInsuranceContributionPercentage.PercentageOf(result.SalaryBrutto);
            result.DisabilityPensionInsuranceContribution = socialParameters.DisabilityPensionInsuranceContributionPercentage.PercentageOf(result.SalaryBrutto);
            result.SicknessInsuranceContribution = socialParameters.SicknessInsuranceContributionPercentage.PercentageOf(result.SalaryBrutto);
            result.SocialInsuranceContribution = socialParameters.TotalPercentage.PercentageOf(result.SalaryBrutto);

            return result;
        }

        private EmploymentContractCalculationResult CalculateDeductibles(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            // koszty uzysku z calej pensji - pomijam na razie
            var deductibleParameters = context.EmployeeContributionParameters.DeductibleParameters;

            result.TaxDeductibleExpenses = deductibleParameters.TaxDeductibleExpensesPercentage.PercentageOf(result.SalaryBrutto);
            result.DriveExpenses = deductibleParameters.DriveExpenses;

            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.CopyrightLawsValue = deductibleParameters.CopyrightLawsPercentage.PercentageOf(salaryMinusSocial);
            result.CopyrightLawsCosts = EmploymentContractConsts.CopyrightLawsCostsPercentage.PercentageOf(result.CopyrightLawsValue);

            return result;
        }

        private static void CalculateHealthInsuranceContribution(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            var healthParameters = context.EmployeeContributionParameters.HealthInsuranceContributionParameters;
            var salaryMinusSocial = result.SalaryBrutto - result.SocialInsuranceContribution;

            result.HealthInsurance = healthParameters.TotalHealthInsurancePercentage.PercentageOf(salaryMinusSocial);
            result.HealthInsurancePaidFromTax = healthParameters.HealthInsurancePaidFromTaxPercentage.PercentageOf(salaryMinusSocial);
            result.HealthInsurancePaidFromNetto = result.HealthInsurance - result.HealthInsurancePaidFromTax;
        }

        private static void CalculateTax(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            var taxRelief = context.EmployeeContributionParameters.TaxRelief;

            // 3. zaliczka na podatek
            result.Tax = Math.Max(0, EmploymentContractConsts.TaxPercentage.PercentageOf(result.TaxBase) - taxRelief - result.HealthInsurancePaidFromTax);
        }

        private static void CalculateNettoSalary(EmploymentContractCalculationResult result)
        {
            result.SalaryNetto = result.SalaryBrutto - result.Tax - result.SocialInsuranceContribution - result.HealthInsurance;
        }
    }
}
