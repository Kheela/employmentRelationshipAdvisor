namespace ERA.Shared.Extensions
{
    public static class PercentExtensions
    {
        public static decimal GetPercent(this decimal value, float percent)
        {
            return value * (decimal)percent / 100;
        }
    }
}
