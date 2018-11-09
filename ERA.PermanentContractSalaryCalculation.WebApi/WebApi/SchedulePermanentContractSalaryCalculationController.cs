using System.Web.Http;
using ERA.PermanentContractSalaryCalculation.Application;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.WebApi.WebApi
{
    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        // GET api/SchedulePermanentContractSalaryCalculation
        public PermanentContractSalaryCalculationResult Get(decimal salaryBrutto, float copyrightLawsPercent = 0)
        {
            var calculator = new PermanentContractSalaryCalculator();

            var context = new PermanentContractSalaryCalculationContext
            {
                Parameters = new PermanentContractEmployeeContributionParameters
                {
                    SocialInsuranceSetting = PermanentContractEmployeeExampleValues.SocialInsuranceSetting,
                    EmploymentRelationshipTaxDeductibleExpensesSetting = PermanentContractEmployeeExampleValues.EmploymentRelationshipTaxDeductibleExpensesSetting,
                    HealthInsuranceSetting = PermanentContractEmployeeExampleValues.HealthInsuranceSetting
                }
            };

            var calculationResult = calculator.Calculate(salaryBrutto, copyrightLawsPercent, context);

            return calculationResult;
        }
    }
}
