using System;
using ERA.PermanentContractSalaryCalculation.Domain.Constants;
using ERA.Shared.Extensions;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation.Calculations
{
    public static class TaxBaseCalculations
    {
        public static EmployeeSalaryCalculationResultBuilder CalculateTaxBase(
            this EmployeeSalaryCalculationResultBuilder builder,
            float copyrightLawsPercent,
            decimal totalSocialInsurance,
            decimal employmentRelationshipDeductibles)
        {
            var salaryMinusSocial = builder.SalaryGross - totalSocialInsurance;

            return builder
                .CalculateCopyrightLawsDeductibles(salaryMinusSocial, copyrightLawsPercent)
                .Calculate(() => builder.Result.TotalDeductibles = employmentRelationshipDeductibles +
                                                                   builder.Result.CopyrightLawsDeductibles +
                                                                   0) //todo: context.Parameters.DriveExpenses;
                .Calculate(() =>
                    builder.Result.TaxBase = Math.Round(salaryMinusSocial - builder.Result.TotalDeductibles));
        }

        private static EmployeeSalaryCalculationResultBuilder CalculateCopyrightLawsDeductibles(
            this EmployeeSalaryCalculationResultBuilder builder,
            decimal salaryMinusSocial,
            float copyrightLawsPercent)
        {
            var copyrightLawsValue = salaryMinusSocial.GetPercent(copyrightLawsPercent);
            builder.Result.CopyrightLawsValue = copyrightLawsValue;
            builder.Result.CopyrightLawsDeductibles = copyrightLawsValue.GetPercent(CopyrightLaws.DeductiblesPercent);

            return builder;
        }
    }
}
