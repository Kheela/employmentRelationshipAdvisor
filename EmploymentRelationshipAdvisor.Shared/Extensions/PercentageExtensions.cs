namespace EmploymentRelationshipAdvisor.Shared.Extensions
{
    public static class PercentageExtensions
    {
        public static decimal PercentageOf(this decimal percentage, decimal value)
        {
            return value * percentage / 100;
        }
    }
}
