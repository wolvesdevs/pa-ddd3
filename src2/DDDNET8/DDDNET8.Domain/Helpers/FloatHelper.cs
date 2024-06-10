namespace DDDNET8.Domain.Helpers
{
    public static class FloatHelper
    {
        public static string RoundString(this float value, int decimalPoint)
        {
            var temp = Math.Round(value, decimalPoint);
            return temp.ToString("F" + decimalPoint);
        }
    }
}
