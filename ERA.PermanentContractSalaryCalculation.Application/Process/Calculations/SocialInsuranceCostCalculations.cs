﻿using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public static class SocialInsuranceCostCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateSocialInsurance(
            this EmployeeSalaryCalculationResultBuilder builder, 
            SocialInsuranceSetting setting)
        {
            return builder
                .Calculate(() => builder.Result.RetirementInsurance = builder.SalaryGross.GetPercent(setting.RetirementInsurancePercent))
                .Calculate(() => builder.Result.DisabilityPensionInsurance = builder.SalaryGross.GetPercent(setting.DisabilityPensionInsurancePercent))
                .Calculate(() => builder.Result.SicknessInsurance = builder.SalaryGross.GetPercent(setting.SicknessInsurancePercent))
                .Calculate(() => builder.Result.TotalSocialInsurance = builder.SalaryGross.GetPercent(setting.TotalPercent));
        }
    }
}
