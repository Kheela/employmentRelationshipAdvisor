namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public class PermanentContractSalaryCalculationContext
    {
        public PermanentContractEmployeeContributionParameters EmployeeContributionParameters { get; set; } = new PermanentContractEmployeeContributionParameters();
    }

    // todo: get from net
    public class PermanentContractEmployeeContributionParameters
    {
        public SocialInsuranceContributionParameters SocialInsuranceContributionParameters { get; set; }
        public DeductibleParameters DeductibleParameters { get; set; }
        public HealthInsuranceContributionParameters HealthInsuranceContributionParameters { get; set; }
        public decimal TaxRelief { get; set; }
    }

    public class SocialInsuranceContributionParameters
    {
        // emerytalne
        public float RetirementInsurancePercent { get; set; }
        public float DisabilityPensionInsurancePercent { get; set; }
        public float SicknessInsurancePercent { get; set; }

        public float TotalPercent => RetirementInsurancePercent +
                                     DisabilityPensionInsurancePercent +
                                     SicknessInsurancePercent;
    }

    public class DeductibleParameters
    {
        // koszty uzysku
        public float TaxDeductibleExpensesPercent { get; set; }
        public decimal DriveExpenses { get; set; }
        public float CopyrightLawsPercent { get; set; }
    }

    public class HealthInsuranceContributionParameters
    {
        public float TotalHealthInsurancePercent { get; set; }
        public float HealthInsurancePaidFromTaxPercent { get; set; }
        public float HealthInsurancePaidFromNettoPercent => TotalHealthInsurancePercent - HealthInsurancePaidFromTaxPercent;
    }
}
