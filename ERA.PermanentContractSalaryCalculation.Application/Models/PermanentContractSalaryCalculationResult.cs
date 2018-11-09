namespace ERA.PermanentContractSalaryCalculation.Application.Models
{
    public class PermanentContractSalaryCalculationResult
    {
        public decimal SalaryBrutto { get; set; }

        public decimal TotalSocialInsurance { get; set; }

        public decimal RetirementInsurance { get; set; }
        public decimal DisabilityPensionInsurance { get; set; }
        public decimal SicknessInsurance { get; set; }

        public decimal TaxDeductibleExpenses { get; set; }

        public decimal CopyrightLawsValue { get; set; }
        public decimal CopyrightLawsCosts { get; set; }

        public decimal TaxBase { get; set; }

        public decimal HealthInsurance { get; set; }
        public decimal DeductibleHealthInsurance { get; set; }
        public decimal HealthInsurancePaidFromNetto { get; set; }

        public decimal MonthlyTaxExemption { get; set; }
        public decimal Tax { get; set; }

        public decimal SalaryNetto { get; set; }
    }
}
