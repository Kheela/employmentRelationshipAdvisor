namespace ERA.PermanentContractSalaryCalculation.Domain.Referential
{
    public class EmployerPaymentCostSetting
    {
        public float SocialInsurancePercent { get; set; }
        // Ubezpieczenie rentowe
        public float DisabilityPensionInsurancePercent { get; set; }
        public float AccidentInsurancePercent { get; set; }
        // Fundusz Pracy
        public float LabourFundPercent { get; set; }
        // Fundusz Gwarantowanych Świadczeń Pracowniczych
        public float GuaranteedEmploymentBenefitFundPercent { get; set; }
    }
}
