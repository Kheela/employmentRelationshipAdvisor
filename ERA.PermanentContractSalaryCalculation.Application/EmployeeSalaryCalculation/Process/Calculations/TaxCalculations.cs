using System;
using ERA.PermanentContractSalaryCalculation.Domain.Constants;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation.Process.Calculations
{
    public static class TaxCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateTax(
            this EmployeeSalaryCalculationResultBuilder builder,
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
