﻿using ERA.PermanentContractSalaryCalculation.Domain.Constants;
using ERA.Shared.Extensions;
using System;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public static class TaxBaseCalculations
    {
        public static CalculationResultBuilder CalculateTaxBase(
            this CalculationResultBuilder builder,
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

        private static CalculationResultBuilder CalculateCopyrightLawsDeductibles(
            this CalculationResultBuilder builder,
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
