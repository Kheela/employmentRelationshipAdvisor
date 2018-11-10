using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation
{
    public static class EmployerExampleValues
    {
        public static EmployerPaymentCostSetting PaymentCostSetting = new EmployerPaymentCostSetting
        {
            SocialInsurancePercent = 9.76f,
            DisabilityPensionInsurancePercent = 6.5f,
            AccidentInsurancePercent = 1.93f,
            LabourFundPercent = 2.45f,
            GuaranteedEmploymentBenefitFundPercent = 0.1f
        };
    }
}
