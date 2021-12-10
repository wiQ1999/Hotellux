using System.Linq;

namespace Hotellux.Tools.Extensions
{
    public static class StringExtension
    {
        public static bool HasDigit(this string value) => value.Any(char.IsDigit);

        public static bool AllDigit(this string value) => value.All(char.IsDigit);

        public static bool ValidPhoneNumber(this string value) => value.Length <= 15 && value.AllDigit();
    }
}
