using System;

namespace NoRealm.Phi.Shared.Utility
{
    /// <summary>
    /// extension methods to support <see cref="object"/> type
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get type of value with null object support
        /// </summary>
        /// <typeparam name="T">type name which implicitly supplied by compiler</typeparam>
        /// <param name="value">value to determine its type</param>
        /// <returns>type of supplied value</returns>
        public static Type TypeOf<T>(this T value)
            => typeof(T);
    }
}
