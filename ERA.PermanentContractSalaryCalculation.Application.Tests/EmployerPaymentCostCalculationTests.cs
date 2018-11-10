using ERA.PermanentContractSalaryCalculation.Application.Process.EmployerPaymentCostCalculation;
using FluentAssertions;
using NUnit.Framework;

namespace ERA.PermanentContractSalaryCalculation.Application.Tests
{
    public class EmployerPaymentCostCalculationTests
    {
        [TestCase(2000, 2414.8)]
        public void PermanentContract__SalaryGross_eq__EmployerPaymentCost_eq(
            decimal salaryGross,
            decimal expectedValue)
        {
            // arrange
            var context = new EmployerPaymentCostCalculationContext
            {
                Parameters = new EmployerPaymentCostParameters
                {
                    EmployerPaymentCostSetting = EmployerExampleValues.PaymentCostSetting
                }
            };

            var calculator = new EmployerPaymentCostCalculator();

            // act
            var result = calculator.Calculate(salaryGross, 0, context);

            // assert
            result.TotalPaymentCost.Should().Be(expectedValue);
        }
    }
}
