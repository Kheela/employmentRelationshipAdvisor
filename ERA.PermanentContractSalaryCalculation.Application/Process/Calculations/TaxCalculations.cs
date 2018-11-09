using ERA.PermanentContractSalaryCalculation.Domain.Enumerations;
using ERA.Shared.Extensions;
using System;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public static class TaxCalculations
    {
        public static CalculationResultBuilder CalculateTax(
            this CalculationResultBuilder builder,
            decimal taxBase,
            decimal taxMonthlyExemption,
            decimal healthInsuranceDeductibles)
        {
            return builder
                .Calculate(() =>
                    builder.Result.Tax = Math.Round(Math.Max(0, CalculateTax(taxBase)) -
                                                    taxMonthlyExemption -
                                                    healthInsuranceDeductibles));
        }

        private static decimal CalculateTax(decimal taxBase)
        {
            return taxBase.GetPercent(ChooseTaxThreshold(taxBase));
        }

        private static float ChooseTaxThreshold(decimal taxBase)
        {
            // todo:
            return TaxThreshold._18;
        }
    }
}
