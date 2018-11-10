using System;
using ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation.Models;

namespace ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation.Process.Calculations
{
    public class EmployeeSalaryCalculationResultBuilder
    {
        public decimal SalaryGross { get; private set; }
        public EmployeeSalaryCalculationResult Result { get; private set; }

        public EmployeeSalaryCalculationResultBuilder SetSalaryGross(decimal salaryGross)
        {
            SalaryGross = salaryGross;

            if (Result != null)
            {
                Result.SalaryGross = SalaryGross;
            }

            return this;
        }

        public EmployeeSalaryCalculationResultBuilder CreateResult()
        {
            Result = new EmployeeSalaryCalculationResult();
            Result.SalaryGross = SalaryGross;
            return this;
        }

        protected internal EmployeeSalaryCalculationResultBuilder Calculate(Action action)
        {
            action();
            return this;
        }
    }
}
