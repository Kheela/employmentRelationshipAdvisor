using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.Process.EmployeeSalaryCalculation
{
    public class EmployeeSalaryCalculationContext
    {
        public EmployeeParameters Parameters { get; set; } = new EmployeeParameters();
    }

    // todo: get from net
    public class EmployeeParameters
    {
        public EmployeeSocialInsuranceSetting SocialInsuranceSetting { get; set; }
        public EmployeeHealthInsuranceSetting HealthInsuranceSetting { get; set; }
        // koszty uzyskania przychodu
        public EmploymentRelationshipTaxSetting EmploymentRelationshipTaxSetting { get; set; } // wybieram 1 z 4 na podstawie informacji z UI
    }
}
