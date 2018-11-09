using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.Process
{
    public class PermanentContractSalaryCalculationContext
    {
        public PermanentContractEmployeeContributionParameters Parameters { get; set; } = new PermanentContractEmployeeContributionParameters();
    }

    // todo: get from net
    public class PermanentContractEmployeeContributionParameters
    {
        public SocialInsuranceSetting SocialInsuranceSetting { get; set; }
        public HealthInsuranceSetting HealthInsuranceSetting { get; set; }
        // koszty uzyskania przychodu
        public EmploymentRelationshipTaxDeductibleExpensesSetting EmploymentRelationshipTaxDeductibleExpensesSetting { get; set; } // wybieram 1 z 4 na podstawie informacji z UI
    }
}
