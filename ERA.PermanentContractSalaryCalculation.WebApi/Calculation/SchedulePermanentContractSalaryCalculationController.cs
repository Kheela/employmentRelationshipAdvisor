﻿using System.Web.Http;

namespace ERA.PermanentContractSalaryCalculation.WebApi.Calculation
{
    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        // GET api/SchedulePermanentContractSalaryCalculation
        public PermanentContractSalaryCalculationResult Get(decimal salaryBrutto)
        {
            var calculator = new PermanentContractSalaryCalculator();

            var context = new PermanentContractSalaryCalculationContext
            {
                EmployeeContributionParameters = new PermanentContractEmployeeContributionParameters
                {
                    SocialInsuranceContributionParameters = PermanentContractEmployeeExampleValues.SocialInsuranceContributionParameters,
                    DeductibleParameters = PermanentContractEmployeeExampleValues.DeductibleParameters,
                    HealthInsuranceContributionParameters = PermanentContractEmployeeExampleValues.HealthInsuranceContributionParameters,
                    TaxRelief = PermanentContractEmployeeExampleValues.TaxRelief
                }
            };

            var calculationResult = calculator.Calculate(salaryBrutto, context);

            return calculationResult;
        }
    }
}
