using System;

namespace Hotellux.Tools.Helpers
{
    public static class EnumHelper
    {
        public static T[] GetValues<T>() => (T[])Enum.GetValues(typeof(T));
    }
}
