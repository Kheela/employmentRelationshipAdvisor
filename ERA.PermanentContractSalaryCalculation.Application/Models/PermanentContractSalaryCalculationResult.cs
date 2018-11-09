namespace ERA.PermanentContractSalaryCalculation.Application.Models
{
    public class PermanentContractSalaryCalculationResult
    {
        public decimal SalaryGross { get; set; }

        public decimal TotalSocialInsurance { get; set; }

        public decimal RetirementInsurance { get; set; }
        public decimal DisabilityPensionInsurance { get; set; }
        public decimal SicknessInsurance { get; set; }

        public decimal TotalDeductibles { get; set; }

        public decimal CopyrightLawsValue { get; set; }
        public decimal CopyrightLawsDeductibles { get; set; }

        public decimal TaxBase { get; set; }

        public decimal HealthInsurance { get; set; }
        public decimal HealthInsuranceDeductibles { get; set; }
        public decimal HealthInsurancePaidFromNetto { get; set; }

        public decimal TaxMonthlyExemption { get; set; }
        public decimal Tax { get; set; }

        public decimal SalaryNett { get; set; }
    }
}
