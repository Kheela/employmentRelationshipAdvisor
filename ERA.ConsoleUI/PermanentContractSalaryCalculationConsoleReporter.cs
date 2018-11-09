using System;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;
using ERA.PermanentContractSalaryCalculation.Domain.Constants;

namespace ERA.ConsoleApi
{
    public interface IPermanentContractSalaryCalculationConsoleReporter
    {
        void Report(EmployeeSalaryCalculationResult result, PermanentContractSalaryCalculationContext context);
    }

    public class PermanentContractSalaryCalculationConsoleReporter : IPermanentContractSalaryCalculationConsoleReporter
    {
        public void Report(EmployeeSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            //todo: zaokraglenia a nie format
            ReportSalaryGross(result.SalaryGross);
            ReportTaxBase(result, context);
            ReportHealthInsuranceContribution(result);
            ReportTax(result, context);
            ReportSalaryNett(result);
        }

        private static void ReportSalaryGross(decimal salaryGross)
        {
            Console.WriteLine($"Pensja brutto: {salaryGross.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportTaxBase(EmployeeSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            ReportSocialInsuranceContributionCalculationInfo(result, context);
            ReportDeductiblesCalculationInfo(result);
            ReportTaxBase(result);
        }

        private static void ReportSocialInsuranceContributionCalculationInfo(EmployeeSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var socialContributionParameters = context.Parameters.SocialInsuranceSetting;

            Console.WriteLine($"ZUS emer. ({socialContributionParameters.RetirementInsurancePercent.ToString("0.00")}%): {result.RetirementInsurance.ToString("0.00")}");
            Console.WriteLine($"ZUS rent. ({socialContributionParameters.DisabilityPensionInsurancePercent.ToString("0.00")}%): {result.DisabilityPensionInsurance.ToString("0.00")}");
            Console.WriteLine($"ZUS chor. ({socialContributionParameters.SicknessInsurancePercent.ToString("0.00")}%): {result.SicknessInsurance.ToString("0.00")}");
            Console.WriteLine($"ZUS ({socialContributionParameters.TotalPercent.ToString("0.00")}%): {result.TotalSocialInsurance.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportDeductiblesCalculationInfo(EmployeeSalaryCalculationResult result)
        {
            Console.WriteLine($"Koszty uzysku: {result.TotalDeductibles.ToString("0.00")}");
            //todo:Console.WriteLine($"Koszty uzysku za dojazd: {result.DriveExpenses.ToString("0.00")}");
            Console.WriteLine($"Prawa autorskie: {result.CopyrightLawsValue.ToString("0.00")}");
            Console.WriteLine($"Koszty z praw autorskich: {result.CopyrightLawsDeductibles.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportTaxBase(EmployeeSalaryCalculationResult result)
        {
            Console.WriteLine($"Podstawa opodatkowania (PIT): {result.TaxBase.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportHealthInsuranceContribution(EmployeeSalaryCalculationResult result)
        {
            Console.WriteLine($"Ubezpieczenie zdrowotne (NFZ) - calosc: {result.HealthInsurance.ToString("0.00")}");
            Console.WriteLine($"NFZ - skladka odliczana od podatku: {result.HealthInsuranceDeductibles.ToString("0.00")}");
            Console.WriteLine($"NFZ - skladka oplacana przez zatrudnionego: {result.HealthInsurancePaidFromNett.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportTax(EmployeeSalaryCalculationResult result, PermanentContractSalaryCalculationContext context)
        {
            var taxRelief = result.TaxMonthlyExemption;

            Console.WriteLine($"Ulga podatkowa: {taxRelief.ToString("0.00")}");
            Console.WriteLine($"Podatek dochodowy (PIT)");
            Console.WriteLine($"({TaxThreshold._18}% * podstawa opodatkowania - ulga - NFZ z podatku): {result.Tax.ToString("0.00")}");
            Console.WriteLine();
        }

        private static void ReportSalaryNett(EmployeeSalaryCalculationResult result)
        {
            Console.WriteLine($"Pensja netto: {result.SalaryNett.ToString("0.00")}");
        }
    }
}
