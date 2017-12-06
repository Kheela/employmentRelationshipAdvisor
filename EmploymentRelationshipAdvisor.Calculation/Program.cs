using System;
using EmploymentRelationshipAdvisor.Calculation.EmploymentContract;

namespace EmploymentRelationshipAdvisor.Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EmploymentContractCalculationContext
            {
                Parameters = new EmploymentContractCalculationParameters
                {
                    EmployeeContributionParameters = new EmploymentContractEmployeeContributionParameters
                    {
                        SocialInsuranceContributionParameters = EmploymentContractEmployeeExampleValues.SocialInsuranceContributionParameters,
                        DeductibleParameters = EmploymentContractEmployeeExampleValues.DeductibleParameters,
                        HealthInsuranceContributionParameters = EmploymentContractEmployeeExampleValues.HealthInsuranceContributionParameters,
                        TaxRelief = EmploymentContractEmployeeExampleValues.TaxRelief
                    }
                }
            };

            var calculator = new EmploymentContractCalculator();
            calculator.Calculate(13000m, context);

            Console.ReadLine();
        }
    }
}
