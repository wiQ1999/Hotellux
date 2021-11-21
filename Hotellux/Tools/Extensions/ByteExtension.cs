using System;

namespace Hotellux.Tools.Extensions
{
    public static class ByteExtension
    {
        public static DateTime CreateDate(this byte[] value) => DateTime.FromBinary(BitConverter.ToInt64(value, 0));
    }
}
