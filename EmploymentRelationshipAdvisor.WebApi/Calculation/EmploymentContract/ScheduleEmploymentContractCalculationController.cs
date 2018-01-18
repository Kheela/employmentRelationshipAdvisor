using EmploymentRelationshipAdvisor.Calculation.EmploymentContract;
using System.Web.Http;

namespace EmploymentRelationshipAdvisor.WebApi.Calculation.EmploymentContract
{
    public class ScheduleEmploymentContractCalculationController : ApiController
    {
        // GET api/ScheduleEmploymentContractCalculation
        public EmploymentContractCalculationResult Get(decimal salaryBrutto)
        {
            var calculator = new EmploymentContractCalculator();

            var context = new EmploymentContractCalculationContext
            {
                EmployeeContributionParameters = new EmploymentContractEmployeeContributionParameters
                {
                    SocialInsuranceContributionParameters = EmploymentContractEmployeeExampleValues.SocialInsuranceContributionParameters,
                    DeductibleParameters = EmploymentContractEmployeeExampleValues.DeductibleParameters,
                    HealthInsuranceContributionParameters = EmploymentContractEmployeeExampleValues.HealthInsuranceContributionParameters,
                    TaxRelief = EmploymentContractEmployeeExampleValues.TaxRelief
                }
            };

            var calculationResult = calculator.Calculate(salaryBrutto, context);

            return calculationResult;
        }
    }
}
