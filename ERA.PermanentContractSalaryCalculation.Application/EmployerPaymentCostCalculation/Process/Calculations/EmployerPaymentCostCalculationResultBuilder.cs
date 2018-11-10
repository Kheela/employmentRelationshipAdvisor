using System;
using ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation.Models;
using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation.Process.Calculations
{
    public class EmployerPaymentCostCalculationResultBuilder
    {
        public decimal SalaryGross { get; private set; }
        public EmployerPaymentCostCalculationResult Result { get; private set; }

        public EmployerPaymentCostCalculationResultBuilder SetSalaryGross(decimal salaryGross)
        {
            SalaryGross = salaryGross;

            if (Result != null)
            {
                Result.SalaryGross = SalaryGross;
            }

            return this;
        }

        public EmployerPaymentCostCalculationResultBuilder CreateResult()
        {
            Result = new EmployerPaymentCostCalculationResult
            {
                SalaryGross = SalaryGross
            };

            return this;
        }

        public EmployerPaymentCostCalculationResultBuilder Calculate(EmployerPaymentCostSetting setting)
        {
            return
                Calculate(() => Result.SocialInsurance = SalaryGross.GetPercent(setting.SocialInsurancePercent))
                    .Calculate(() => Result.DisabilityPensionInsurance = SalaryGross.GetPercent(setting.DisabilityPensionInsurancePercent))
                    .Calculate(() => Result.AccidentInsurance = SalaryGross.GetPercent(setting.AccidentInsurancePercent))
                    .Calculate(() => Result.LabourFund = SalaryGross.GetPercent(setting.LabourFundPercent))
                    .Calculate(() => Result.GuaranteedEmploymentBenefitFund = SalaryGross.GetPercent(setting.GuaranteedEmploymentBenefitFundPercent));
        }

        private EmployerPaymentCostCalculationResultBuilder Calculate(Action action)
        {
            action();
            return this;
        }
    }
}
