using DDDNET8.Domain.Exceptions;

namespace DDDNET8.Domain.Helpers
{
    public static class Guard
    {
        public static void IsNull(object o, string message)
        {
            if (o == null)
            {
                throw new InputException(message);
            }
        }

        public static float IsFloat(string text, string message)
        {
            float floadValue;
            if (!float.TryParse(text, out floadValue))
            {
                throw new InputException(message);
            }

            return floadValue;
        }
    }
}
