namespace NoRealm.Phi.Shared
{
    /// <summary>
    /// Represent a placeholder for a value
    /// </summary>
    public class Value
    {
        /// <summary>
        /// Represent a value which is not specified
        /// </summary>
        public static readonly Value None = new ValueNone();

        /// <summary>
        /// this class used to represent values which didn't specified
        /// </summary>
        private class ValueNone : Value { }

        /// <summary>
        /// this constructor to prevent creating instances from this class
        /// </summary>
        private Value() { }
    }
}
