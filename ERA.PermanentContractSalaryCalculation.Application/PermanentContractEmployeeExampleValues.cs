using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application
{
    public static class PermanentContractEmployeeExampleValues
    {
        public static SocialInsuranceSetting SocialInsuranceSetting = new SocialInsuranceSetting
        {
            RetirementInsurancePercent = 9.76f,
            DisabilityPensionInsurancePercent = 1.5f,
            SicknessInsurancePercent = 2.45f
        };

        public static EmploymentRelationshipTaxDeductibleExpensesSetting
            EmploymentRelationshipTaxDeductibleExpensesSetting = new EmploymentRelationshipTaxDeductibleExpensesSetting
            {
                Amount = 111.25m
            };

        public static HealthInsuranceSetting HealthInsuranceSetting = new HealthInsuranceSetting
        {
            DeductibleHealthInsurancePercent = 7.75f,
            HealthInsurancePercent = 9f
        };

        public static decimal TaxRelief = 560m / 12;
    }
}
