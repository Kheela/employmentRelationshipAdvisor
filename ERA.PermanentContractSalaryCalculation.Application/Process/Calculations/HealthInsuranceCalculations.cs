﻿using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using ERA.Shared.Extensions;
using System;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public static class HealthInsuranceCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateHealthInsurance(
            this EmployeeSalaryCalculationResultBuilder builder,
            decimal totalSocialInsurance,
            HealthInsuranceSetting setting)
        {
            var salaryMinusSocial = builder.SalaryGross - totalSocialInsurance;

            return builder
                .Calculate(() =>
                    builder.Result.HealthInsurance = salaryMinusSocial.GetPercent(setting.HealthInsurancePercent))
                .Calculate(() =>
                    builder.Result.HealthInsuranceDeductibles =
                        Math.Round(salaryMinusSocial.GetPercent(setting.DeductibleHealthInsurancePercent)))
                .Calculate(() =>
                    builder.Result.HealthInsurancePaidFromNett =
                        builder.Result.HealthInsurance - builder.Result.HealthInsuranceDeductibles);
        }
    }
}
