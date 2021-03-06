﻿using System;
using ERA.PermanentContractSalaryCalculation.Application.Models;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation.Calculations
{
    public interface IEmployeeSalaryCalculationResultBuilder
    {
        EmployeeSalaryCalculationResult Result { get; }
        decimal SalaryGross { get; }

        EmployeeSalaryCalculationResultBuilder CreateResult();
        EmployeeSalaryCalculationResultBuilder SetSalaryGross(decimal salaryGross);
    }

    public class EmployeeSalaryCalculationResultBuilder : IEmployeeSalaryCalculationResultBuilder
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
