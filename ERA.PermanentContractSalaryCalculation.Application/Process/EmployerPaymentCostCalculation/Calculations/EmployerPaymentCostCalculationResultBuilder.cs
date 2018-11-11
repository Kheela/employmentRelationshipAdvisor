using System;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation.Calculations
{
    public interface IEmployerPaymentCostCalculationResultBuilder
    {
        EmployerPaymentCostCalculationResult Result { get; }
        decimal SalaryGross { get; }

        EmployerPaymentCostCalculationResultBuilder Calculate(EmployerPaymentCostSetting setting);
        EmployerPaymentCostCalculationResultBuilder CreateResult();
        EmployerPaymentCostCalculationResultBuilder SetSalaryGross(decimal salaryGross);
    }

    public class EmployerPaymentCostCalculationResultBuilder : IEmployerPaymentCostCalculationResultBuilder
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
                    .Calculate(() =>
                        Result.DisabilityPensionInsurance =
                            SalaryGross.GetPercent(setting.DisabilityPensionInsurancePercent))
                    .Calculate(
                        () => Result.AccidentInsurance = SalaryGross.GetPercent(setting.AccidentInsurancePercent))
                    .Calculate(() => Result.LabourFund = SalaryGross.GetPercent(setting.LabourFundPercent))
                    .Calculate(() =>
                        Result.GuaranteedEmploymentBenefitFund =
                            SalaryGross.GetPercent(setting.GuaranteedEmploymentBenefitFundPercent))
                    .Calculate(() => Result.TotalPaymentCost = SalaryGross + Result.TotalAdditionalCosts);
        }

        private EmployerPaymentCostCalculationResultBuilder Calculate(Action action)
        {
            action();
            return this;
        }
    }
}
