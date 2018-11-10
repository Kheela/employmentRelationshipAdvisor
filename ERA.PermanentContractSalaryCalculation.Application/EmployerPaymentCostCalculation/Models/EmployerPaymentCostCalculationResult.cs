namespace ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation.Models
{
    public class EmployerPaymentCostCalculationResult
    {
        public decimal TotalPaymentCost { get; set; }
        public decimal SocialInsurance { get; set; }
        public decimal HealthInsurance { get; set; }
        public decimal AccidentInsurance { get; set; }
        // Fundusz Pracy
        public decimal LabourFund { get; set; }
        // Fundusz Gwarantowanych Świadczeń Pracowniczych
        public decimal GuaranteedEmploymentBenefitFund { get; set; }
    }
}
