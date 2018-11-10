using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation;
using ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public interface IPermanentContractSalaryCalculator
    {
        PermanentContractSalary Calculate(
            decimal salaryGross,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent);
    }

    public class PermanentContractSalaryCalculator : IPermanentContractSalaryCalculator
    {
        private IEmployeeSalaryCalculator _employeeSalaryCalculator = new EmployeeEmployeeSalaryCalculator();
        private IEmployerPaymentCostCalculator _employerPaymentCostCalculator = new EmployerPaymentCostCalculator();

        public PermanentContractSalary Calculate(decimal salaryGross, float copyrightLawsPercent)
        {
            var employeeSalaryCalculationResult = CalculateEmployeePart(salaryGross, copyrightLawsPercent);
            var employerPaymentCostCalculationResult = CalculateEmployerPart(salaryGross, copyrightLawsPercent);

            return new PermanentContractSalary
            {
                EmployeeSalaryCalculationResult = employeeSalaryCalculationResult,
                EmployerPaymentCostCalculationResult = employerPaymentCostCalculationResult
            };
        }

        private EmployerPaymentCostCalculationResult CalculateEmployerPart(decimal salaryGross, float copyrightLawsPercent)
        {
            var employerPaymentCostCalculationContext = new EmployerPaymentCostCalculationContext
            {
                Parameters = new EmployerPaymentCostParameters
                {
                    EmployerPaymentCostSetting = EmployerExampleValues.PaymentCostSetting
                }
            };

            return _employerPaymentCostCalculator.Calculate(salaryGross,
                copyrightLawsPercent, employerPaymentCostCalculationContext);
        }

        private EmployeeSalaryCalculationResult CalculateEmployeePart(decimal salaryGross, float copyrightLawsPercent)
        {
            var employeeSalaryCalculationContext = new EmployeeSalaryCalculationContext
            {
                Parameters = new EmployeeParameters
                {
                    SocialInsuranceSetting = EmployeeExampleValues.SocialInsuranceSetting,
                    EmploymentRelationshipTaxSetting = EmployeeExampleValues.EmploymentRelationshipTaxSetting,
                    HealthInsuranceSetting = EmployeeExampleValues.HealthInsuranceSetting
                }
            };

            return _employeeSalaryCalculator.Calculate(salaryGross, copyrightLawsPercent, employeeSalaryCalculationContext);
        }
    }
}
