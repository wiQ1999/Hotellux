using System.Linq;

namespace Hotellux.Tools.Extensions
{
    public static class StringExtension
    {
        public static bool HasDigit(this string value) => value.Any(char.IsDigit);
    }
}
