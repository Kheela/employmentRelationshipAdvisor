using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public class PermanentContractSalaryCalculationContext
    {
        public PermanentContractEmployeeContributionParameters EmployeeContributionParameters { get; set; } = new PermanentContractEmployeeContributionParameters();
    }

    // todo: get from net
    public class PermanentContractEmployeeContributionParameters
    {
        public SocialInsuranceSetting SocialInsuranceSetting { get; set; } // z sieci
        public DeductibleParameters DeductibleParameters { get; set; }
        public HealthInsuranceContributionParameters HealthInsuranceContributionParameters { get; set; }
        public decimal TaxRelief { get; set; }
    }

    // do odliczenia
    public class DeductibleParameters
    {
        // koszty uzyskania przychodu
        public float TaxDeductibleExpensesPercent { get; set; } // z sieci
        public decimal DriveExpenses { get; set; } // z UI
        public float CopyrightLawsPercent { get; set; } // z UI
    }

    public class HealthInsuranceContributionParameters
    {
        public float TotalHealthInsurancePercent { get; set; } // tyle trzeba wplacic do zusu
        public float HealthInsurancePaidFromTaxPercent { get; set; } // zmiejsza podatek dochodowy
        public float HealthInsurancePaidFromNettoPercent => TotalHealthInsurancePercent - HealthInsurancePaidFromTaxPercent;
    }
}
