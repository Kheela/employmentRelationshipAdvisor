using System.Web.Http;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.WebApi.WebApi
{
    public enum SalaryType : byte
    {
        Gross = 1,
        Nett = 2
    }

    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        private IPermanentContractSalaryCalculator _calculator;

        public SchedulePermanentContractSalaryCalculationController(
            IPermanentContractSalaryCalculator calculator)
        {
            _calculator = calculator;
        }

        // GET api/SchedulePermanentContractSalaryCalculation
        public PermanentContractSalary Get(decimal salary, SalaryType salaryType, float copyrightLawsPercent = 0)
        {
            return salaryType == SalaryType.Gross 
                ? _calculator.CalculateFromGross(salary, copyrightLawsPercent)
                : _calculator.CalculateFromNett(salary, copyrightLawsPercent);
        }
    }
}
