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
                Parameters = new PermanentContractEmployeeContributionParameters
                {
                    SocialInsuranceSetting = PermanentContractEmployeeExampleValues.SocialInsuranceSetting,
                    EmploymentRelationshipTaxSetting = PermanentContractEmployeeExampleValues.EmploymentRelationshipTaxSetting,
                    HealthInsuranceSetting = PermanentContractEmployeeExampleValues.HealthInsuranceSetting
                }
            };

            var calculationResult = calculator.Calculate(13000m, 80f, context);
            consoleReporter.Report(calculationResult, context);

            Console.WriteLine("Wcisnij <ENTER> aby zakonczyc");
            Console.ReadLine();
        }
    }
}
