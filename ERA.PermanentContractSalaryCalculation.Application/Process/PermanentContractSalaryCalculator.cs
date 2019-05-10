using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation;
using ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public interface IPermanentContractSalaryCalculator
    {
        PermanentContractSalary CalculateFromGross(
            decimal salaryGross,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent);

        PermanentContractSalary CalculateFromNett(
            decimal salaryNett,
            //todo: decimal driveExpenses,
            float copyrightLawsPercent);
    }

    public class PermanentContractSalaryCalculator : IPermanentContractSalaryCalculator
    {
        private readonly IEmployeeSalaryCalculator _employeeSalaryCalculator;
        private readonly IEmployerPaymentCostCalculator _employerPaymentCostCalculator;

        public PermanentContractSalaryCalculator(
            IEmployeeSalaryCalculator employeeSalaryCalculator,
            IEmployerPaymentCostCalculator employerPaymentCostCalculator)
        {
            _employeeSalaryCalculator = employeeSalaryCalculator;
            _employerPaymentCostCalculator = employerPaymentCostCalculator;
        }

        public PermanentContractSalary CalculateFromGross(decimal salaryGross, float copyrightLawsPercent)
        {
            var employeeSalaryCalculationResult = CalculateEmployeePart(salaryGross, copyrightLawsPercent);
            var employerPaymentCostCalculationResult = CalculateEmployerPart(salaryGross, copyrightLawsPercent);

            return new PermanentContractSalary
            {
                EmployeeSalaryCalculationResult = employeeSalaryCalculationResult,
                EmployerPaymentCostCalculationResult = employerPaymentCostCalculationResult
            };
        }

        public PermanentContractSalary CalculateFromNett(decimal salaryNett, float copyrightLawsPercent)
        {
            //todo:
            var employeeSalaryCalculationResult = CalculateEmployeePart(salaryNett, copyrightLawsPercent);
            var employerPaymentCostCalculationResult = CalculateEmployerPart(salaryNett, copyrightLawsPercent);

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
