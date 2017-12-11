using System;
using EmploymentRelationshipAdvisor.Calculation.EmploymentContract;

namespace EmploymentRelationshipAdvisor.Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new EmploymentContractCalculator();
            var consoleReporter = new EmploymentContractCalculationResultConsoleReporter();

            var context = new EmploymentContractCalculationContext
            {
                EmployeeContributionParameters = new EmploymentContractEmployeeContributionParameters
                {
                    SocialInsuranceContributionParameters = EmploymentContractEmployeeExampleValues.SocialInsuranceContributionParameters,
                    DeductibleParameters = EmploymentContractEmployeeExampleValues.DeductibleParameters,
                    HealthInsuranceContributionParameters = EmploymentContractEmployeeExampleValues.HealthInsuranceContributionParameters,
                    TaxRelief = EmploymentContractEmployeeExampleValues.TaxRelief
                }
            };

            var calculationResult = calculator.Calculate(13000m, context);
            consoleReporter.Report(calculationResult, context);

            Console.WriteLine("Wcisnij <ENTER> aby zakonczyc");
            Console.ReadLine();
        }
    }
}
