using System;
using ERA.PermanentContractSalaryCalculation.Domain.Referential;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation.Calculations
{
    public static class HealthInsuranceCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateHealthInsurance(
            this EmployeeSalaryCalculationResultBuilder builder,
            decimal totalSocialInsurance,
            EmployeeHealthInsuranceSetting setting)
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
