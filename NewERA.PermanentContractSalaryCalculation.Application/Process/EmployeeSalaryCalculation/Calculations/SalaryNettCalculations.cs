using System;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation.Calculations
{
    public static class SalaryNettCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateSalaryNett(
            this EmployeeSalaryCalculationResultBuilder builder,
            decimal tax,
            decimal totalSocialInsurance,
            decimal healthInsurance)
        {
            return builder
                .Calculate(() => builder.Result.SalaryNett = Math.Round(builder.SalaryGross -
                                                                        tax -
                                                                        totalSocialInsurance -
                                                                        healthInsurance));
        }
    }
}
