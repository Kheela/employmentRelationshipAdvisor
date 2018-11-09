using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.Application
{
    public static class PermanentContractEmployeeExampleValues
    {
        public static SocialInsuranceContributionParameters SocialInsuranceContributionParameters = new SocialInsuranceContributionParameters
        {
            RetirementInsurancePercent = 9.76f,
            DisabilityPensionInsurancePercent = 1.5f,
            SicknessInsurancePercent = 2.45f
        };

        public static DeductibleParameters DeductibleParameters = new DeductibleParameters
        {
            TaxDeductibleExpensesPercent = 0f,
            DriveExpenses = 111.25m,
            CopyrightLawsPercent = 80f
        };

        public static HealthInsuranceContributionParameters HealthInsuranceContributionParameters = new HealthInsuranceContributionParameters
        {
            HealthInsurancePaidFromTaxPercent = 7.75f,
            TotalHealthInsurancePercent = 9f
        };

        public static decimal TaxRelief = 560m / 12;
    }
}
