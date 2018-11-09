using System.Web.Http;
using ERA.PermanentContractSalaryCalculation.Application;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.WebApi.WebApi
{
    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        // GET api/SchedulePermanentContractSalaryCalculation
        public PermanentContractSalaryCalculationResult Get(decimal salaryGross, float copyrightLawsPercent = 0)
        {
            var calculator = new PermanentContractSalaryCalculator();

            var context = new PermanentContractSalaryCalculationContext
            {
                Parameters = new PermanentContractEmployeeContributionParameters
                {
                    SocialInsuranceSetting = PermanentContractEmployeeExampleValues.SocialInsuranceSetting,
                    EmploymentRelationshipTaxSetting = PermanentContractEmployeeExampleValues.EmploymentRelationshipTaxSetting,
                    HealthInsuranceSetting = PermanentContractEmployeeExampleValues.HealthInsuranceSetting
                }
            };

            var calculationResult = calculator.Calculate(salaryGross, copyrightLawsPercent, context);

            return calculationResult;
        }
    }
}
