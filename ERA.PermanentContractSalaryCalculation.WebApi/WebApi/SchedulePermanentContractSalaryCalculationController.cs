using System.Web.Http;
using ERA.PermanentContractSalaryCalculation.Application;
using ERA.PermanentContractSalaryCalculation.Application.Models;
using ERA.PermanentContractSalaryCalculation.Application.Process;

namespace ERA.PermanentContractSalaryCalculation.WebApi.WebApi
{
    public class SchedulePermanentContractSalaryCalculationController : ApiController
    {
        // GET api/SchedulePermanentContractSalaryCalculation
        public PermanentContractSalaryCalculationResult Get(decimal salaryBrutto)
        {
            var calculator = new PermanentContractSalaryCalculator();

            var context = new PermanentContractSalaryCalculationContext
            {
                EmployeeContributionParameters = new PermanentContractEmployeeContributionParameters
                {
                    SocialInsuranceSetting = PermanentContractEmployeeExampleValues.SocialInsuranceSetting,
                    DeductibleParameters = PermanentContractEmployeeExampleValues.DeductibleParameters,
                    HealthInsuranceContributionParameters = PermanentContractEmployeeExampleValues.HealthInsuranceContributionParameters,
                    TaxRelief = PermanentContractEmployeeExampleValues.TaxRelief
                }
            };

            var calculationResult = calculator.Calculate(salaryBrutto, context);

            return calculationResult;
        }
    }
}
