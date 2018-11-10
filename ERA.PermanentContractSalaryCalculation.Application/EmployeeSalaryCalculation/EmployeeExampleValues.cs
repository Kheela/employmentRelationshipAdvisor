using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.EmployeeSalaryCalculation
{
    public static class EmployeeExampleValues
    {
        public static EmployeeSocialInsuranceSetting SocialInsuranceSetting = new EmployeeSocialInsuranceSetting
        {
            RetirementInsurancePercent = 9.76f,
            DisabilityPensionInsurancePercent = 1.5f,
            SicknessInsurancePercent = 2.45f
        };

        public static EmploymentRelationshipTaxSetting EmploymentRelationshipTaxSetting =
            new EmploymentRelationshipTaxSetting
            {
                DeductiblesAmount = 111.25m
            };

        public static EmployeeHealthInsuranceSetting HealthInsuranceSetting = new EmployeeHealthInsuranceSetting
        {
            DeductibleHealthInsurancePercent = 7.75f,
            HealthInsurancePercent = 9f
        };
    }
}
