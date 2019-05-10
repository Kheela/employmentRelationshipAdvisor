namespace ERA.PermanentContractSalaryCalculation.Application.Models
{
    public class EmployerPaymentCostCalculationResult
    {
        public decimal TotalPaymentCost { get; set; }

        public decimal SalaryGross { get; set; }

        public decimal SocialInsurance { get; set; }
        // Ubezpieczenie rentowe
        public decimal DisabilityPensionInsurance { get; set; }
        public decimal AccidentInsurance { get; set; }
        // Fundusz Pracy
        public decimal LabourFund { get; set; }
        // Fundusz Gwarantowanych Świadczeń Pracowniczych
        public decimal GuaranteedEmploymentBenefitFund { get; set; }

        public decimal TotalAdditionalCosts => SocialInsurance +
                                               DisabilityPensionInsurance +
                                               AccidentInsurance +
                                               LabourFund +
                                               GuaranteedEmploymentBenefitFund;
    }
}
