namespace EmploymentRelationshipAdvisor.Calculation.EmploymentContract
{
    public class EmploymentContractCalculationContext
    {
        public EmploymentContractCalculationParameters Parameters { get; set; }
    }

    public class EmploymentContractCalculationParameters
    {
        public EmploymentContractEmployeeContributionParameters EmployeeContributionParameters { get; set; } = new EmploymentContractEmployeeContributionParameters();
    }

    // todo: get from net
    public class EmploymentContractEmployeeContributionParameters
    {
        public SocialInsuranceContributionParameters SocialInsuranceContributionParameters { get; set; }

        public DeductibleParameters DeductibleParameters { get; set; }

        public HealthInsuranceContributionParameters HealthInsuranceContributionParameters { get; set; }

        public decimal TaxRelief { get; set; }
    }

    public class SocialInsuranceContributionParameters
    {
        // emerytalne
        public decimal PensionInsuranceContributionPercentage { get; set; }

        public decimal DisabilityPensionInsuranceContributionPercentage { get; set; }

        public decimal SicknessInsuranceContributionPercentage { get; set; }
    }

    public class DeductibleParameters
    {
        // koszty uzysku
        public decimal TaxDeductibleExpensesPercentage { get; set; }

        public decimal DriveExpenses { get; set; }

        public decimal CopyrightLawsPercentage { get; set; }
    }

    public class HealthInsuranceContributionParameters
    {
        public decimal TotalHealthInsurancePercentage { get; set; }

        public decimal HealthInsurancePaidFromTaxPercentage { get; set; }

        public decimal HealthInsurancePaidFromNettoPercentage { get { return TotalHealthInsurancePercentage - HealthInsurancePaidFromTaxPercentage; } }
    }
}
