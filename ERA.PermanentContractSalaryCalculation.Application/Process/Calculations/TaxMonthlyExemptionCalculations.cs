namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public static class TaxMonthlyExemptionCalculations
    {
        public static CalculationResultBuilder CalculateTaxMonthlyExemption(
            this CalculationResultBuilder builder)
        {
            // 1/12 z kwoty wolnej od podatku (bo jest ona roczna)
            // od 2018r wyliczana inaczej w zaleznosci od podstawy opodatkowania
            return builder
                .Calculate(() => builder.Result.TaxMonthlyExemption = 560m / 12);
        }
    }
}
