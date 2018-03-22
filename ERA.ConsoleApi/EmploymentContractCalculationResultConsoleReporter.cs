using ERA.Calculation.EmploymentContract;
using System;

namespace ERA.ConsoleApi
{
    public interface IEmploymentContractCalculationResultConsoleReporter
    {
        void Report(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context);
    }

    public class EmploymentContractCalculationResultConsoleReporter : IEmploymentContractCalculationResultConsoleReporter
    {
        public void Report(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            //todo: zaokraglenia a nie format
            ReportBruttoSalary(result.SalaryBrutto);
            ReportTaxBase(result, context);
            ReportHealthInsuranceContribution(result);
            ReportTax(result, context);
            ReportNettoSalary(result);
        }

        private static void ReportBruttoSalary(decimal bruttoSalary)
        {
            Console.WriteLine($"Pensja brutto: {bruttoSalary.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportTaxBase(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            ReportSocialInsuranceContributionCalculationInfo(result, context);
            ReportDeductiblesCalculationInfo(result);
            ReportTaxBase(result);
        }

        private static void ReportSocialInsuranceContributionCalculationInfo(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            var socialContributionParameters = context.EmployeeContributionParameters.SocialInsuranceContributionParameters;

            Console.WriteLine($"ZUS emer. ({socialContributionParameters.PensionInsuranceContributionPercentage.ToString("0.00")}%): {result.PensionInsuranceContribution.ToString("0.00")}");
            Console.WriteLine($"ZUS rent. ({socialContributionParameters.DisabilityPensionInsuranceContributionPercentage.ToString("0.00")}%): {result.DisabilityPensionInsuranceContribution.ToString("0.00")}");
            Console.WriteLine($"ZUS chor. ({socialContributionParameters.SicknessInsuranceContributionPercentage.ToString("0.00")}%): {result.SicknessInsuranceContribution.ToString("0.00")}");
            Console.WriteLine($"ZUS ({socialContributionParameters.TotalPercentage.ToString("0.00")}%): {result.SocialInsuranceContribution.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportDeductiblesCalculationInfo(EmploymentContractCalculationResult result)
        {
            Console.WriteLine($"Koszty uzysku: {result.TaxDeductibleExpenses.ToString("0.00")}");
            Console.WriteLine($"Koszty uzysku za dojazd: {result.DriveExpenses.ToString("0.00")}");
            Console.WriteLine($"Prawa autorskie: {result.CopyrightLawsValue.ToString("0.00")}");
            Console.WriteLine($"Koszty z praw autorskich: {result.CopyrightLawsCosts.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportTaxBase(EmploymentContractCalculationResult result)
        {
            Console.WriteLine($"Podstawa opodatkowania (PIT): {result.TaxBase.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportHealthInsuranceContribution(EmploymentContractCalculationResult result)
        {
            Console.WriteLine($"Ubezpieczenie zdrowotne (NFZ) - calosc: {result.HealthInsurance.ToString("0.00")}");
            Console.WriteLine($"NFZ - skladka odliczana od podatku: {result.HealthInsurancePaidFromTax.ToString("0.00")}");
            Console.WriteLine($"NFZ - skladka oplacana przez zatrudnionego: {result.HealthInsurancePaidFromNetto.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportTax(EmploymentContractCalculationResult result, EmploymentContractCalculationContext context)
        {
            var taxRelief = context.EmployeeContributionParameters.TaxRelief;

            Console.WriteLine($"Ulga podatkowa: {taxRelief.ToString("0.00")}");
            Console.WriteLine($"Podatek dochodowy (PIT)");
            Console.WriteLine($"({EmploymentContractConsts.TaxPercentage}% * podstawa opodatkowania - ulga - NFZ z podatku): {result.Tax.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportNettoSalary(EmploymentContractCalculationResult result)
        {
            Console.WriteLine($"Pensja netto: {result.SalaryNetto.ToString("0.00")}");
        }
    }
}
