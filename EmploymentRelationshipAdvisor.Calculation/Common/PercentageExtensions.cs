namespace EmploymentRelationshipAdvisor.Calculation.Common
{
    public static class PercentageExtensions
    {
        public static decimal CalculatePercentage(this decimal percentage, decimal value)
        {
            return value * percentage / 100;
        }
    }
}
