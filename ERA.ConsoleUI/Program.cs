using System;
using ERA.PermanentContractSalaryCalculation.Application;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.ConsoleApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new PermanentContractSalaryCalculator();
            var consoleReporter = new PermanentContractSalaryCalculationConsoleReporter();

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

            var calculationResult = calculator.Calculate(13000m, context);
            consoleReporter.Report(calculationResult, context);

            Console.WriteLine("Wcisnij <ENTER> aby zakonczyc");
            Console.ReadLine();
        }
    }
}
