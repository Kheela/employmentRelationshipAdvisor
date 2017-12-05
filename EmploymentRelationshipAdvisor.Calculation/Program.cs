using System;
using EmploymentRelationshipAdvisor.Calculation.PermanentContract;

namespace EmploymentRelationshipAdvisor.Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PermanentContractCalculationContext
            {
                Parameters = new PermanentContractCalculationParameters
                {
                    EmployeeContributionParameters = new EmployeePermanentContractContributionParameters
                    {
                        SocialInsuranceContributionParameters = EmployeePermanentContractExampleValues.SocialInsuranceContributionParameters,
                        DeductibleParameters = EmployeePermanentContractExampleValues.DeductibleParameters,
                        HealthInsuranceContributionParameters = EmployeePermanentContractExampleValues.HealthInsuranceContributionParameters,
                        TaxRelief = EmployeePermanentContractExampleValues.TaxRelief
                    }
                }
            };

            var calculator = new PermanentContractCalculator();
            calculator.Calculate(13000m, context);

            Console.ReadLine();
        }
    }
}
