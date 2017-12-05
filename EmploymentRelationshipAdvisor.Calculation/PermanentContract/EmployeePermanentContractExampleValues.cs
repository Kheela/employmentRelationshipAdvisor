namespace EmploymentRelationshipAdvisor.Calculation.PermanentContract
{
    public static class EmployeePermanentContractExampleValues
    {
        public static SocialInsuranceContributionParameters SocialInsuranceContributionParameters = new SocialInsuranceContributionParameters
        {
            PensionInsuranceContributionPercentage = 9.76m,
            DisabilityPensionInsuranceContributionPercentage = 1.5m,
            SicknessInsuranceContributionPercentage = 2.45m
        };

        public static DeductibleParameters DeductibleParameters = new DeductibleParameters
        {
            TaxDeductibleExpensesPercentage = 0m,
            DriveExpenses = 111.25m,
            CopyrightLawsPercentage = 80m
        };

        public static HealthInsuranceContributionParameters HealthInsuranceContributionParameters = new HealthInsuranceContributionParameters
        {
            HealthInsurancePaidFromTaxPercentage = 7.75m,
            TotalHealthInsurancePercentage = 9m
        };

        public static decimal TaxRelief = 560m / 12;
    }
}
