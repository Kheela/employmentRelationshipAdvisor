namespace ERA.PermanentContractSalaryCalculation.Application.Models
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
}
