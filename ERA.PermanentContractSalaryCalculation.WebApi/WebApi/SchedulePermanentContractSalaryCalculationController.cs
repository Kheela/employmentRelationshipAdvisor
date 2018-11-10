using System.Web.Http;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.WebApi.WebApi
{
    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        private IPermanentContractSalaryCalculator _calculator = new PermanentContractSalaryCalculator();

        // GET api/SchedulePermanentContractSalaryCalculation
        public PermanentContractSalary Get(decimal salaryGross, float copyrightLawsPercent = 0)
        {
            return _calculator.Calculate(salaryGross, copyrightLawsPercent);
        }
    }
}
