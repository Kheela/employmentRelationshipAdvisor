using System;
using ERA.PermanentContractSalaryCalculation.Application.Models;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.Calculations
{
    public class CalculationResultBuilder
    {
        public decimal SalaryGross { get; private set; }
        public EmployeeSalaryCalculationResult Result { get; private set; }

        public CalculationResultBuilder SetSalaryGross(decimal salaryGross)
        {
            SalaryGross = salaryGross;

            if (Result != null)
            {
                Result.SalaryGross = SalaryGross;
            }

            return this;
        }

        public CalculationResultBuilder CreateResult()
        {
            Result = new EmployeeSalaryCalculationResult();
            Result.SalaryGross = SalaryGross;
            return this;
        }

        public CalculationResultBuilder Calculate(Action action)
        {
            action();
            return this;
        }
    }
}
