using ERA.Calculation.PermanentContract;
using System.Web.Http;

namespace ERA.WebApi.Calculation.EmploymentContract
{
    public class ScheduleEmploymentContractCalculationController : ApiController
    {
        // GET api/ScheduleEmploymentContractCalculation
        public PermanentContractSalaryCalculationResult Get(decimal salaryBrutto)
        {
            var calculator = new PermanentContractSalaryCalculator();

            var context = new PermanentContractSalaryCalculationContext
            {
                EmployeeContributionParameters = new PermanentContractEmployeeContributionParameters
                {
                    SocialInsuranceContributionParameters = PermanentContractEmployeeExampleValues.SocialInsuranceContributionParameters,
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
