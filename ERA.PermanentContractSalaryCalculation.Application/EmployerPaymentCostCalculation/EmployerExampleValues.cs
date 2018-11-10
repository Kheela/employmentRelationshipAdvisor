﻿using ERA.PermanentContractSalaryCalculation.Domain.Referential;

namespace ERA.PermanentContractSalaryCalculation.Application.EmployerPaymentCostCalculation
{
    public static class EmployerExampleValues
    {
        public static SocialInsuranceSetting SocialInsuranceSetting = new SocialInsuranceSetting
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

        public static HealthInsuranceSetting HealthInsuranceSetting = new HealthInsuranceSetting
        {
            DeductibleHealthInsurancePercent = 7.75f,
            HealthInsurancePercent = 9f
        };
    }
}
