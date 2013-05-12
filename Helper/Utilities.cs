namespace Helper
{
    internal static class Utilities
    {
        public static short HIWord(object value)
        {
            return (short)((uint)value >> 16);
        }

        public static short LOWord(object value)
        {
            return (short)value;
        }
    }
}
