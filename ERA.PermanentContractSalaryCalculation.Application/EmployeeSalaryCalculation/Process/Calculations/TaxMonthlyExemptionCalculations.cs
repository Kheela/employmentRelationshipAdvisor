namespace ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation.Process.Calculations
{
    public static class TaxMonthlyExemptionCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateTaxMonthlyExemption(
            this EmployeeSalaryCalculationResultBuilder builder)
        {
            // 1/12 z kwoty wolnej od podatku (bo jest ona roczna)
            // od 2018r wyliczana inaczej w zaleznosci od podstawy opodatkowania
            return builder
                .Calculate(() => builder.Result.TaxMonthlyExemption = 560m / 12);
        }
    }
}
