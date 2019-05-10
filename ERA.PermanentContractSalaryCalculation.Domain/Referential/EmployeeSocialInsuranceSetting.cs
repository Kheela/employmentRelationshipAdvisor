using System.ComponentModel.DataAnnotations.Schema;

namespace ERA.PermanentContractSalaryCalculation.Domain.Referential
{
    public class EmployeeSocialInsuranceSetting
    {
        // emerytalne
        public float RetirementInsurancePercent { get; set; }
        // rentowe
        public float DisabilityPensionInsurancePercent { get; set; }
        // chorobowe
        public float SicknessInsurancePercent { get; set; }

        [NotMapped]
        public float TotalPercent => RetirementInsurancePercent +
                                     DisabilityPensionInsurancePercent +
                                     SicknessInsurancePercent;
    }
}
