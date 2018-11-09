using System;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public static class SalaryNettCalculations
    {
        public static CalculationResultBuilder CalculateSalaryNett(
            this CalculationResultBuilder builder,
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
