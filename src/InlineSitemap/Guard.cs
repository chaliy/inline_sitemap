using System;

namespace InlineSitemap
{
    class Guard
    {
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentIsNotNull(object arg, string name)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
