namespace NoRealm.Phi.Shared.Utility
{
    /// <summary>
    /// extension methods to support <see cref="Value"/> type
    /// </summary>
    public static class ValueExtensions
    {
        /// <summary>
        /// Determine if input value is an instance of <see cref="Value"/>
        /// </summary>
        /// <typeparam name="T">value type</typeparam>
        /// <param name="value">value to be checked</param>
        /// <returns>true if input value is an instance of <see cref="Value"/>; false otherwise</returns>
        public static bool IsValue<T>(this T value)
            => value is Value;

        /// <summary>
        /// Determine if input value is a <see cref="Value.None"/>
        /// </summary>
        /// <typeparam name="T">value type</typeparam>
        /// <param name="value">value to be checked</param>
        /// <returns>true if input value is a <see cref="Value.None"/>; false otherwise</returns>
        public static bool IsNone<T>(this T value)
            => value is Value v && v == Value.None;
    }
}
