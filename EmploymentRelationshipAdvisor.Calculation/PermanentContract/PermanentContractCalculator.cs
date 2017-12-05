using System;
using EmploymentRelationshipAdvisor.Calculation.Common;

namespace EmploymentRelationshipAdvisor.Calculation.PermanentContract
{
    public class PermanentContractCalculationResult
    {

    }

    public class PermanentContractCalculator
    {
        public PermanentContractCalculationResult Calculate(decimal monthBruttoSalary,
                                                            PermanentContractCalculationContext context)
        {
            Console.WriteLine($"Pensja brutto: {monthBruttoSalary.ToString("0.00")}");
            Console.WriteLine();

            // 1. podstawa opodatkowania
            // 1.1. skladki zus
            var socialContributionParameters = context.Parameters.EmployeeContributionParameters.SocialInsuranceContributionParameters;

            var pensionInsuranceContribution = socialContributionParameters.PensionInsuranceContributionPercentage.CalculatePercentage(monthBruttoSalary);
            Console.WriteLine($"ZUS emer. ({socialContributionParameters.PensionInsuranceContributionPercentage.ToString("0.00")}%): {pensionInsuranceContribution.ToString("0.00")}");

            var disabilityPensionInsuranceContribution = socialContributionParameters.DisabilityPensionInsuranceContributionPercentage.CalculatePercentage(monthBruttoSalary);
            Console.WriteLine($"ZUS rent. ({socialContributionParameters.DisabilityPensionInsuranceContributionPercentage.ToString("0.00")}%): {disabilityPensionInsuranceContribution.ToString("0.00")}");

            var sicknessInsuranceContribution = socialContributionParameters.SicknessInsuranceContributionPercentage.CalculatePercentage(monthBruttoSalary);
            Console.WriteLine($"ZUS chor. ({socialContributionParameters.SicknessInsuranceContributionPercentage.ToString("0.00")}%): {sicknessInsuranceContribution.ToString("0.00")}");

            var socialInsuranceContributionPercentage = socialContributionParameters.PensionInsuranceContributionPercentage + socialContributionParameters.DisabilityPensionInsuranceContributionPercentage + socialContributionParameters.SicknessInsuranceContributionPercentage;
            var socialInsuranceContribution = socialInsuranceContributionPercentage.CalculatePercentage(monthBruttoSalary);
            Console.WriteLine($"ZUS ({socialInsuranceContributionPercentage.ToString("0.00")}%): {socialInsuranceContribution.ToString("0.00")}");
            Console.WriteLine();

            // 1.2 koszty uzysku
            // koszty uzysku z calej pensji - pomijam na razie
            var taxDeductibleExpenses = context.Parameters.EmployeeContributionParameters.DeductibleParameters.TaxDeductibleExpensesPercentage.CalculatePercentage(monthBruttoSalary);
            Console.WriteLine($"Koszty uzysku: {taxDeductibleExpenses.ToString("0.00")}");

            var driveExpenses = context.Parameters.EmployeeContributionParameters.DeductibleParameters.DriveExpenses;
            Console.WriteLine($"Koszty uzysku za dojazd: {driveExpenses.ToString("0.00")}");

            var salaryMinusSocial = monthBruttoSalary - socialInsuranceContribution;

            var copyrightLawsValue = context.Parameters.EmployeeContributionParameters.DeductibleParameters.CopyrightLawsPercentage.CalculatePercentage(salaryMinusSocial);
            Console.WriteLine($"Prawa autorskie: {copyrightLawsValue.ToString("0.00")}");

            const decimal copyrightLawsCostsPercentage = 50m;
            var copyrightLawsCosts = copyrightLawsCostsPercentage.CalculatePercentage(copyrightLawsValue);
            Console.WriteLine($"Koszty z praw autorskich: {copyrightLawsCosts.ToString("0.00")}");

            var taxBase = salaryMinusSocial - copyrightLawsCosts;
            Console.WriteLine($"Podstawa opodatkowania (PIT): {taxBase.ToString("0.00")}");
            Console.WriteLine();

            // 2. skladki na ubezpieczenie zdrowotne
            var healthInsurance = context.Parameters.EmployeeContributionParameters.HealthInsuranceContributionParameters.TotalHealthInsurancePercentage.CalculatePercentage(salaryMinusSocial);
            Console.WriteLine($"Ubezpieczenie zdrowotne (NFZ) - calosc: {healthInsurance.ToString("0.00")}");

            var healthInsurancePaidFromTax = context.Parameters.EmployeeContributionParameters.HealthInsuranceContributionParameters.HealthInsurancePaidFromTaxPercentage.CalculatePercentage(salaryMinusSocial);
            Console.WriteLine($"NFZ - skladka odliczana od podatku: {healthInsurancePaidFromTax.ToString("0.00")}");

            var healthInsurancePaidFromNetto = healthInsurance - healthInsurancePaidFromTax;
            Console.WriteLine($"NFZ - skladka oplacana przez zatrudnionego: {healthInsurancePaidFromNetto.ToString("0.00")}");
            Console.WriteLine();

            // 3. zaliczka na podatek
            var taxRelief = context.Parameters.EmployeeContributionParameters.TaxRelief;
            Console.WriteLine($"Ulga podatkowa: {taxRelief.ToString("0.00")}");

            const decimal taxPercentage = 18m; // todo: dodac prog 32% itd..
            var tax = taxPercentage.CalculatePercentage(taxBase) - taxRelief - healthInsurancePaidFromTax;
            //todo: zaokraglenia a nie format
            Console.WriteLine($"Podatek dochodowy (PIT)");
            Console.WriteLine($"({taxPercentage}% * podstawa opodatkowania - ulga - NFZ z podatku): {tax.ToString("0.00")}");
            Console.WriteLine();

            // 4. netto
            var monthNettoSalary = monthBruttoSalary - tax - socialInsuranceContribution - healthInsurance;
            Console.WriteLine($"Pensja netto: {monthNettoSalary.ToString("0.00")}");

            return new PermanentContractCalculationResult();
        }
    }
}
