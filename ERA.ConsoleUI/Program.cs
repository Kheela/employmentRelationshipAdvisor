using System;
using ERA.PermanentContractSalaryCalculation.Application;
using ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation;
using ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation.Process;

namespace ERA.ConsoleApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new EmployeeEmployeeSalaryCalculator();
            var consoleReporter = new PermanentContractSalaryCalculationConsoleReporter();

            var context = new EmployeeSalaryCalculationContext
            {
                Parameters = new EmployeeParameters
                {
                    SocialInsuranceSetting = EmployeeExampleValues.SocialInsuranceSetting,
                    EmploymentRelationshipTaxSetting = EmployeeExampleValues.EmploymentRelationshipTaxSetting,
                    HealthInsuranceSetting = EmployeeExampleValues.HealthInsuranceSetting
                }
            };

            var calculationResult = calculator.Calculate(13000m, 80f, context);
            consoleReporter.Report(calculationResult, context);

            Console.WriteLine("Wcisnij <ENTER> aby zakonczyc");
            Console.ReadLine();
        }
    }
}
