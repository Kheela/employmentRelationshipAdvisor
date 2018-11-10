using System.Web.Http;
using ERA.PermanentContractSalaryCalculation.Application;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.WebApi.WebApi
{
    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        // GET api/SchedulePermanentContractSalaryCalculation
        public EmployeeSalaryCalculationResult Get(decimal salaryGross, float copyrightLawsPercent = 0)
        {
            var calculator = new EmployeeEmployeeSalaryCalculator();

            var context = new EmployeeSalaryCalculationContext
            {
                Parameters = new EmployeeParameters
                {
                    SocialInsuranceSetting = EmployeeExampleValues.SocialInsuranceSetting,
                    EmploymentRelationshipTaxSetting = EmployeeExampleValues.EmploymentRelationshipTaxSetting,
                    HealthInsuranceSetting = EmployeeExampleValues.HealthInsuranceSetting
                }
            };

            var calculationResult = calculator.Calculate(salaryGross, copyrightLawsPercent, context);

            return calculationResult;
        }
    }
}
